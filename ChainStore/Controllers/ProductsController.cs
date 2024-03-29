﻿using System;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers;

public class ProductsController : Controller
{
    private const string IndexAction = "Index";
    private const string DefaultController = "Stores";
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IStoreRepository _storeRepository;

    public ProductsController(ICategoryRepository categoryRepository, IProductRepository productRepository,
        IStoreRepository storeRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _storeRepository = storeRepository;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult ReplenishProduct(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var product = _productRepository.GetOne(id.Value);
        if (product == null) return View("ProductNotFound", id.Value);

        var categoryProductsViewModel = new ReplenishProductsViewModel
        {
            Product = product,
            Category = _categoryRepository.GetOne(product.CategoryId),
            QuantityOfProductsToReplenish = 1
        };

        return View(categoryProductsViewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult ReplenishProduct(ReplenishProductsViewModel replenishProductsViewModel)
    {
        if (!ModelState.IsValid) return View("ProductNotFound", replenishProductsViewModel.ProductId);

        var productToReplenish = _productRepository.GetOne(replenishProductsViewModel.ProductId);
        if (productToReplenish == null) return View("ProductNotFound", replenishProductsViewModel.ProductId);

        var storeToReplenish = _productRepository.GetStoreOfSpecificProduct(productToReplenish.Id);
        if (storeToReplenish == null) return View("ProductNotFound", replenishProductsViewModel.ProductId);

        for (var i = 1; i <= replenishProductsViewModel.QuantityOfProductsToReplenish; i++)
        {
            var product = new Product(Guid.NewGuid(), productToReplenish.Name,
                productToReplenish.PriceInUAH,
                ProductStatus.OnSale, replenishProductsViewModel.CategoryId);
            _productRepository.AddProductToStore(product, storeToReplenish.Id);
        }

        return RedirectToAction(IndexAction, DefaultController);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AddProductToStore(Guid? storeId, Guid? categoryId)
    {
        if (storeId == null || categoryId == null) return RedirectToAction(IndexAction, DefaultController);

        var store = _storeRepository.GetOne(storeId.Value);
        if (store == null) return View("StoreNotFound", storeId.Value);

        var category = _categoryRepository.GetOne(categoryId.Value);
        if (category == null) return View("CategoryNotFound", storeId.Value); //CategoryNotFoundPage

        var createProductViewModel = new CreateProductViewModel
        { StoreId = store.Id, Category = category, QuantityOfProductsToAdd = 1 };
        return View(createProductViewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddProductToStore(CreateProductViewModel createProductViewModel)
    {
        if (!ModelState.IsValid) return RedirectToAction(IndexAction, DefaultController);

        var store = _storeRepository.GetOne(createProductViewModel.StoreId);
        if (store == null) return View("StoreNotFound", createProductViewModel.StoreId);

        for (var i = 1; i <= createProductViewModel.QuantityOfProductsToAdd; i++)
        {
            var product = new Product(Guid.NewGuid(), createProductViewModel.Name, createProductViewModel.Price,
                ProductStatus.OnSale, createProductViewModel.CategoryId);
            _productRepository.AddProductToStore(product, store.Id);
        }

        return RedirectToAction(IndexAction, DefaultController);

    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProduct(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var productToDel = _productRepository.GetOne(id.Value);
        if (productToDel == null) return View("ProductNotFound", id.Value);

        var deleteProductViewModel = new DeleteProductViewModel { Product = productToDel };
        return View(deleteProductViewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteProduct(DeleteProductViewModel deleteProductViewModel)
    {
        var productToDel = _productRepository.GetOne(deleteProductViewModel.ProductId);
        if (productToDel == null) return View("ProductNotFound", deleteProductViewModel.ProductId);

        var store = _productRepository.GetStoreOfSpecificProduct(productToDel.Id);
        if (store == null) return View("StoreNotFound", Guid.Empty);

        var categoryWithStoreSpecificProducts =
            store.Categories.First(e => e.Id.Equals(productToDel.CategoryId));
        var storeAndCategorySpecificProducts = categoryWithStoreSpecificProducts.Products.Where(product =>
                product.Name.Equals(productToDel.Name) && product.ProductStatus.Equals(productToDel.ProductStatus))
            .ToList();

        if (storeAndCategorySpecificProducts.Count == 0) return RedirectToAction(IndexAction, DefaultController);

        foreach (var product in storeAndCategorySpecificProducts)
            _productRepository.DeleteOne(product.Id);


        return RedirectToAction(IndexAction, DefaultController);
    }
}
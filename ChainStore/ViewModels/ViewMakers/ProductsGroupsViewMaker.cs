using ChainStore.Domain.DomainCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ChainStore.ViewModels.ViewMakers
{
    public class ProductsGroupsViewMaker
    {
        public List<IGrouping<string, Product>> MakeProductsGroupsFromCategory(Category category)
        {
            var productsInCategory =
                from product in category.Products
                where product.ProductStatus.Equals(ProductStatus.OnSale)
                group product by product.Name;
            return productsInCategory.ToList();
        }

        public List<IGrouping<string, Product>> MakeProductsGroups(IReadOnlyCollection<Product> products)
        {
            var productsInCategory =
                from product in products
                where product.ProductStatus.Equals(ProductStatus.OnSale)
                group product by product.Name;
            return productsInCategory.ToList();
        }
    }
}
using ChainStore.Actions.ApplicationServices;
using ChainStore.ActionsImpl.ApplicationServicesImpl;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.DataAccessLayerImpl.RepositoriesImpl;
using ChainStore.ViewModels.ViewMakers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ChainStore
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MyDbContext>(options => options.UseSqlServer(_config.GetConnectionString("ChainStoreDBVer2"), assembly => assembly.MigrationsAssembly(typeof(MyDbContext).Assembly.FullName)));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();
            services.AddScoped<IStoreRepository, SqlStoreRepository>();
            services.AddScoped<ICategoryRepository, SqlCategoryRepository>();
            services.AddScoped<IClientRepository, SqlClientRepository>();
            services.AddScoped<IPurchaseRepository, SqlPurchaseRepository>();
            services.AddScoped<IBookRepository, SqlBookRepository>();
            services.AddScoped<IProductRepository, SqlProductRepository>();
            services.AddScoped<IMallRepository, SqlMallRepository>();
            services.AddScoped<ClientDetailsViewModelMaker>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IReservationService, BookService>();
            services.AddTransient<ProductsGroupsViewMaker>();
            services.AddScoped<IClientService, ClientService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseAuthentication();
            app.UseMvc(routes => routes.MapRoute("default", "{controller=Stores}/{action=Index}/{id?}"));
            MyDbContextSeedData.Initialize(app.ApplicationServices, _config).Wait();
        }
    }
}

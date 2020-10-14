using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ChainStore.DataAccessLayerImpl.DbModels;

namespace ChainStore.DataAccessLayerImpl
{
    public class MyDbContextSeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MyDbContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                var email = configuration.GetValue<string>("AdminUserEmail");
                var password = configuration.GetValue<string>("AdminUserPswd");
                var adminId = Guid.NewGuid();

                var user = new ApplicationUser
                {
                    Id = adminId.ToString(),
                    Email = email.ToLower(),
                    UserName = email.ToLower(),
                    EmailConfirmed = true,
                    CreationTime = DateTimeOffset.Now,
                    ClientDbModelId = adminId
                };

                if (!context.Users.Any(u => u.NormalizedUserName == email.ToUpper()))
                {
                    var res = await userManager.CreateAsync(user, password);
                    if (res.Succeeded)
                    {
                        var adminRole = new IdentityRole("Admin");
                        if (!context.Roles.Any(e => e.NormalizedName == adminRole.Name.ToUpper()))
                        {
                            var res1 = await roleManager.CreateAsync(adminRole);
                            if (res1.Succeeded)
                            {
                                var adminUser = context.Users.Find(user.Id);
                                await userManager.AddToRoleAsync(adminUser, adminRole.Name);
                            }
                        }
                        try
                        {
                            context.Clients.Add(new ClientDbModel(new Guid(user.Id), "Husk", 0));
                            await context.SaveChangesAsync();
                        }
                        catch (Exception)
                        {
                            throw new ApplicationException();
                        }
                    }
                }
            }
        }
    }
}
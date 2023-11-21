using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;
using WebApplication4.Models;

namespace WebApplication4.Data {
    public class UsersInitializer {

        public static async void Initialize(IServiceProvider services,AccidentContext context) {
            context.Database.EnsureCreated();

            if (context.Users.Any() && context.Persons.Any() && context.Roles.Any()) {
                return;
            }

            using (var transaction = context.Database.BeginTransaction()) {

                Person p1 = new Person { FirstName = "Thibeau", LastName = "GOOVAERTS", employementType = "Interne", Role = 4, WorkingHours="08-16" };
                Person p2 = new Person { FirstName = "Mathis", LastName = "GRIMONSTER", employementType = "Interne", Role = 4, WorkingHours = "08-16" };
                Person p3 = new Person { FirstName = "Justine", LastName = "CREPIN", employementType = "Interne", Role = 4, WorkingHours = "08-16" };
                Person p4 = new Person { FirstName = "Marianne", LastName = "DEVILLE", employementType = "Interne", Role = 4 , WorkingHours = "08-16" };
                Person p5 = new Person { FirstName = "Noah", LastName = "DEPIENNE", employementType = "Interne", Role = 4 , WorkingHours = "08-16" };

                using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    var roleResponsable = new IdentityRole { Name = "responsable" };
                    var roleRH = new IdentityRole { Name = "rh" };
                    var roleContremaitre = new IdentityRole { Name = "contremaitre" };
                    var roleEmploye = new IdentityRole { Name = "employe" };

                    await roleManager.CreateAsync(roleResponsable);
                    await roleManager.CreateAsync(roleRH);
                    await roleManager.CreateAsync(roleContremaitre);
                    await roleManager.CreateAsync(roleEmploye);

                    var user1 = new User { UserName = "thibeau", Person = p1 };
                    await userManager.CreateAsync(user1, /* 404 : PasswordNotFound */);
                    await userManager.AddToRoleAsync(user1, "contremaitre");

                    var user2 = new User { UserName = "mathis", Person = p2 };
                    await userManager.CreateAsync(user2, /* 404 : PasswordNotFound */);
                    await userManager.AddToRoleAsync(user2, "employe");

                    var user3 = new User { UserName = "justine", Person = p3 };
                    await userManager.CreateAsync(user3, /* 404 : PasswordNotFound */);
                    await userManager.AddToRoleAsync(user3, "contremaitre");

                    var user4 = new User { UserName = "marianne", Person = p4 };
                    await userManager.CreateAsync(user4, /* 404 : PasswordNotFound */);
                    await userManager.AddToRoleAsync(user4, "employe");

                    var user5 = new User { UserName = "noah", Person = p5 };
                    await userManager.CreateAsync(user5, /* 404 : PasswordNotFound */);
                    await userManager.AddToRoleAsync(user5, "responsable");

                }

            }
            
        }
    }
}

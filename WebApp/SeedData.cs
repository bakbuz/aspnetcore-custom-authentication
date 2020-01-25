using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Data;

namespace WebApp
{
    internal class SeedData
    {
        internal static void Initialize(IServiceProvider serviceProvider)
        {
            var dataContext = (DataContext)serviceProvider.GetService(typeof(DataContext));

            var ensureCreated = dataContext.Database.EnsureCreated();
            if (ensureCreated)
            {
                var roles = new List<Role>();
                roles.Add(new Role { Name = "Admin" });
                roles.Add(new Role { Name = "Manager" });
                roles.Add(new Role { Name = "Editor" });

                dataContext.Roles.AddRange(roles);
                dataContext.SaveChanges();



                var user1 = new User();
                user1.Username = "admin";
                user1.FirstName = "Admin User";
                user1.LastName = "(tüm sayfaları görebilmeli)";
                user1.Roles = new List<UserRole> { new UserRole { RoleId = roles.Single(q => q.Name == "Admin").Id } };

                var user2 = new User();
                user2.Username = "manager";
                user2.FirstName = "Manager User";
                user2.LastName = "(sadece manager sayfasını ve kendi profilini görebilmeli)";
                user2.Roles = new List<UserRole> { new UserRole { RoleId = roles.Single(q => q.Name == "Manager").Id } };

                var user3 = new User();
                user3.Username = "editor";
                user3.FirstName = "Editor User";
                user3.LastName = "(sadece editor sayfasını ve kendi profilini görebilmeli)";
                user3.Roles = new List<UserRole> { new UserRole { RoleId = roles.Single(q => q.Name == "Editor").Id } };



                dataContext.Users.Add(user1);
                dataContext.Users.Add(user2);
                dataContext.Users.Add(user3);
                dataContext.SaveChanges();




                //var ur = new UserRole();
                //ur.UserId = user.Id;
                //ur.RoleId = role.Id;

                //dataContext.UserRoles.Add(ur);
                //dataContext.SaveChanges();
            }
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.MvcWebUI.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roller
            if (!context.Roles.Any(i=> i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="admin",Description="admin rolü"};

                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };

                manager.Create(role);
            }


            //kullanıcılar
            if (!context.Users.Any(i => i.Name == "omer"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() 
                {
                    Name="omer ",Surname="can",UserName="omercan",Email="omercancandar@gmail.com"
                };


                manager.Create(user,"123456789");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.Name == "omercannot"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser()
                {
                    Name = "cant ",
                    Surname = "canthenot",
                    UserName = "omercannot",
                    Email = "omercancandarr@gmail.com"
                };


                manager.Create(user, "123456789");
                manager.AddToRole(user.Id, "user");
            }

            


            base.Seed(context);
        }

    }
}
namespace INote.API.Migrations
{
    using INote.API.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<INote.API.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(INote.API.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = new ApplicationUser
                {
                    UserName = "caglaryalcin41@gmail.com",
                    Email = "caglaryalcin41@gmail.com",
                    EmailConfirmed = true
                };

                userManager.Create(user, "Ankara1.");
                user.Notes = new HashSet<Note>();

                user.Notes.Add(new Note
                {
                    Title = "Sample Note 1",
                    Content = "Kocaelim benim biricik sevgilim s�yle senden ba�ka kimim var benim seninle a�lar�m seninle g�lerim s�yle senden ba�ka kimim var benim",
                    CreatedTime = DateTime.Now
                });

                user.Notes.Add(new Note
                {
                    AuthorId = user.Id,
                    Title = "Sample Note 2",
                    Content = "G�nl�mde sadece k�rfezim yatar, b�t�n gemiler ise k�rfezde batar, bu alemde kimse ba�lamaz bizi buras� basra de�il izmit k�rfezi. ",
                    CreatedTime = DateTime.Now
                });

                context.Entry(user).State = EntityState.Modified;
            }
        }
    }
}

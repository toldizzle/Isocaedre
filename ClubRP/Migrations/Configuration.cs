namespace ClubRP.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClubRP.Models.ClubDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClubRP.Models.ClubDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Messages.AddOrUpdate(new Message { Texte = "Bienvenue sur notre forum, vous y retrouverez les mises à jour, ainsi que la liste des groupes de joueurs. Vous pouvez faire une petite présentation de vous ici et de vos attentes en temps que joueur.", PostID = 1, MessageID = 1 });
            context.Posts.AddOrUpdate(new Post { Titre = "Introduction", Creation = DateTime.Now, ID = 1 });
            context.SaveChanges();
        }
    }
}

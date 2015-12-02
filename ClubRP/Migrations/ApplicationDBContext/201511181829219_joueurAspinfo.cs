namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joueurAspinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Joueurs", "AspNetUsersInfoSupID", c => c.Int());
            AddColumn("dbo.AspNetUsersInfoSups", "Joueur_JoueurID", c => c.Int());
            CreateIndex("dbo.AspNetUsersInfoSups", "Joueur_JoueurID");
            AddForeignKey("dbo.AspNetUsersInfoSups", "Joueur_JoueurID", "dbo.Joueurs", "JoueurID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsersInfoSups", "Joueur_JoueurID", "dbo.Joueurs");
            DropIndex("dbo.AspNetUsersInfoSups", new[] { "Joueur_JoueurID" });
            DropColumn("dbo.AspNetUsersInfoSups", "Joueur_JoueurID");
            DropColumn("dbo.Joueurs", "AspNetUsersInfoSupID");
        }
    }
}

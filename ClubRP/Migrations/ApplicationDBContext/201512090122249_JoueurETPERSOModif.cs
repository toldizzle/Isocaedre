namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoueurETPERSOModif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Joueurs", "Personnage_PersonnageID", "dbo.Personnages");
            DropIndex("dbo.Joueurs", new[] { "Personnage_PersonnageID" });
            CreateIndex("dbo.Personnages", "JoueurID");
            AddForeignKey("dbo.Personnages", "JoueurID", "dbo.Joueurs", "JoueurID", cascadeDelete: true);
            DropColumn("dbo.Joueurs", "Personnage_PersonnageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Joueurs", "Personnage_PersonnageID", c => c.Int());
            DropForeignKey("dbo.Personnages", "JoueurID", "dbo.Joueurs");
            DropIndex("dbo.Personnages", new[] { "JoueurID" });
            CreateIndex("dbo.Joueurs", "Personnage_PersonnageID");
            AddForeignKey("dbo.Joueurs", "Personnage_PersonnageID", "dbo.Personnages", "PersonnageID");
        }
    }
}

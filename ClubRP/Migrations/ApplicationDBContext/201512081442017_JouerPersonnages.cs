namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JouerPersonnages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Joueurs", "Personnage_PersonnageID", "dbo.Personnages");
            DropIndex("dbo.Joueurs", new[] { "Personnage_PersonnageID" });
            DropColumn("dbo.Personnages", "JoueurID");
            RenameColumn(table: "dbo.Personnages", name: "Personnage_PersonnageID", newName: "JoueurID");
            CreateIndex("dbo.Personnages", "JoueurID");
            AddForeignKey("dbo.Personnages", "JoueurID", "dbo.Joueurs", "JoueurID", cascadeDelete: true);
            DropColumn("dbo.Joueurs", "Personnage_PersonnageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Joueurs", "Personnage_PersonnageID", c => c.Int());
            DropForeignKey("dbo.Personnages", "JoueurID", "dbo.Joueurs");
            DropIndex("dbo.Personnages", new[] { "JoueurID" });
            RenameColumn(table: "dbo.Personnages", name: "JoueurID", newName: "Personnage_PersonnageID");
            AddColumn("dbo.Personnages", "JoueurID", c => c.Int(nullable: false));
            CreateIndex("dbo.Joueurs", "Personnage_PersonnageID");
            AddForeignKey("dbo.Joueurs", "Personnage_PersonnageID", "dbo.Personnages", "PersonnageID");
        }
    }
}

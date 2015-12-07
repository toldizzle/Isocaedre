namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbSetPersonnages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Joueurs", "Personnage_PersonnageID", "dbo.Personnages");
            DropIndex("dbo.Joueurs", new[] { "Personnage_PersonnageID" });
            DropColumn("dbo.Joueurs", "Personnage_PersonnageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Joueurs", "Personnage_PersonnageID", c => c.Int());
            CreateIndex("dbo.Joueurs", "Personnage_PersonnageID");
            AddForeignKey("dbo.Joueurs", "Personnage_PersonnageID", "dbo.Personnages", "PersonnageID");
        }
    }
}

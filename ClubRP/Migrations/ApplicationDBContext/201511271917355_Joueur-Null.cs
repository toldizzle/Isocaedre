namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoueurNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Joueurs", "GroupeID", "dbo.Groupes");
            DropIndex("dbo.Joueurs", new[] { "GroupeID" });
            AlterColumn("dbo.Joueurs", "GroupeID", c => c.Int());
            AlterColumn("dbo.Joueurs", "PersonnageID", c => c.Int());
            CreateIndex("dbo.Joueurs", "GroupeID");
            AddForeignKey("dbo.Joueurs", "GroupeID", "dbo.Groupes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Joueurs", "GroupeID", "dbo.Groupes");
            DropIndex("dbo.Joueurs", new[] { "GroupeID" });
            AlterColumn("dbo.Joueurs", "PersonnageID", c => c.Int(nullable: false));
            AlterColumn("dbo.Joueurs", "GroupeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Joueurs", "GroupeID");
            AddForeignKey("dbo.Joueurs", "GroupeID", "dbo.Groupes", "ID", cascadeDelete: true);
        }
    }
}

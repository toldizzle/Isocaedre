namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class groupeEtJoueur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groupes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Description = c.String(),
                        Creation = c.DateTime(nullable: false),
                        AspNetUserID = c.String(),
                        Auteur = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Joueurs",
                c => new
                    {
                        JoueurID = c.Int(nullable: false, identity: true),
                        AspNetUserID = c.String(),
                        Nom = c.String(),
                        Classe = c.String(),
                        Maitre = c.Boolean(nullable: false),
                        Specialisation = c.String(),
                        GroupeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JoueurID)
                .ForeignKey("dbo.Groupes", t => t.GroupeID, cascadeDelete: true)
                .Index(t => t.GroupeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Joueurs", "GroupeID", "dbo.Groupes");
            DropIndex("dbo.Joueurs", new[] { "GroupeID" });
            DropTable("dbo.Joueurs");
            DropTable("dbo.Groupes");
        }
    }
}

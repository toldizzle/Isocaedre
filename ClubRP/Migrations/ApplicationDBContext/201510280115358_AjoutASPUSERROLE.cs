namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutASPUSERROLE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "PostID", "dbo.Posts");
            DropIndex("dbo.Messages", new[] { "PostID" });
            CreateTable(
                "dbo.AspNetUsersInfoSups",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Role = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        ImageNom = c.String(),
                        ImageType = c.String(),
                        ImageTaille = c.Int(nullable: false),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Id", "dbo.AspNetUsersInfoSups", "ID");
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        AuteurMessage = c.String(),
                        Texte = c.String(),
                        DateMessage = c.DateTime(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Description = c.String(),
                        Creation = c.DateTime(nullable: false),
                        Auteur = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.AspNetUsersInfoSups");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropTable("dbo.AspNetUsersInfoSups");
            CreateIndex("dbo.Messages", "PostID");
            AddForeignKey("dbo.Messages", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
        }
    }
}

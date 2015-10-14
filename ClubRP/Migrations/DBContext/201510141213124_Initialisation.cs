namespace ClubRP.Migrations.DBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Texte = c.String(),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Creation = c.DateTime(nullable: false),
                        NbReponse = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "PostID", "dbo.Posts");
            DropIndex("dbo.Messages", new[] { "PostID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
        }
    }
}

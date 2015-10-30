namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementMessageEtPostsUSER : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "utilisateur_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Posts", "utilisateur_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "utilisateur_Id");
            CreateIndex("dbo.Posts", "utilisateur_Id");
            AddForeignKey("dbo.Messages", "utilisateur_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Posts", "utilisateur_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Messages", "AuteurMessage");
            DropColumn("dbo.Posts", "Auteur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Auteur", c => c.String());
            AddColumn("dbo.Messages", "AuteurMessage", c => c.String());
            DropForeignKey("dbo.Posts", "utilisateur_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "utilisateur_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "utilisateur_Id" });
            DropIndex("dbo.Messages", new[] { "utilisateur_Id" });
            DropColumn("dbo.Posts", "utilisateur_Id");
            DropColumn("dbo.Messages", "utilisateur_Id");
        }
    }
}

namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementMessageEtPostsUSER2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "utilisateur_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "utilisateur_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "utilisateur_Id" });
            DropIndex("dbo.Posts", new[] { "utilisateur_Id" });
            AddColumn("dbo.Messages", "utilisateurName", c => c.String());
            AddColumn("dbo.Posts", "utilisateurName", c => c.String());
            DropColumn("dbo.Messages", "utilisateur_Id");
            DropColumn("dbo.Posts", "utilisateur_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "utilisateur_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "utilisateur_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Posts", "utilisateurName");
            DropColumn("dbo.Messages", "utilisateurName");
            CreateIndex("dbo.Posts", "utilisateur_Id");
            CreateIndex("dbo.Messages", "utilisateur_Id");
            AddForeignKey("dbo.Posts", "utilisateur_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Messages", "utilisateur_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

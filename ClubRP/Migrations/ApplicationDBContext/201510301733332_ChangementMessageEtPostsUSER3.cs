namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class ChangementMessageEtPostsUSER3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "AspNetUserID", c => c.String());
            AddColumn("dbo.Posts", "AspNetUserID", c => c.String());
            DropColumn("dbo.Messages", "utilisateurName");
            DropColumn("dbo.Posts", "utilisateurName");
        }

        public override void Down()
        {
            AddColumn("dbo.Posts", "utilisateurName", c => c.String());
            AddColumn("dbo.Messages", "utilisateurName", c => c.String());
            DropColumn("dbo.Posts", "AspNetUserID");
            DropColumn("dbo.Messages", "AspNetUserID");
        }
    }
}
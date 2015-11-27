namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class ChangementPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Description", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Posts", "Description");
        }
    }
}
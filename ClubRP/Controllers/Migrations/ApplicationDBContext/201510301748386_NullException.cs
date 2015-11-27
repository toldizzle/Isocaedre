namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class NullException : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Auteur", c => c.String());
            AddColumn("dbo.Posts", "Auteur", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Posts", "Auteur");
            DropColumn("dbo.Messages", "Auteur");
        }
    }
}
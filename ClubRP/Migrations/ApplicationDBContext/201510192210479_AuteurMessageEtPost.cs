namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class AuteurMessageEtPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Auteur", c => c.String());
            AddColumn("dbo.Messages", "AuteurMessage", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Messages", "AuteurMessage");
            DropColumn("dbo.Posts", "Auteur");
        }
    }
}
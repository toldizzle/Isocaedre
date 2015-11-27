namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class Auteur_Post2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Auteur");
        }

        public override void Down()
        {
            AddColumn("dbo.Posts", "Auteur", c => c.String());
        }
    }
}
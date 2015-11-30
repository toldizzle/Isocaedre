namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class MEssageUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Titre");
        }

        public override void Down()
        {
            AddColumn("dbo.Messages", "Titre", c => c.String());
        }
    }
}
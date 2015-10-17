namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auteur_Post : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Auteur", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Auteur");
        }
    }
}

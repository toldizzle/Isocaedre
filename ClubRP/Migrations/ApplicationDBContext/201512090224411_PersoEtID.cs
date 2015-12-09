namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersoEtID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnages", "AspUserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personnages", "AspUserID");
        }
    }
}

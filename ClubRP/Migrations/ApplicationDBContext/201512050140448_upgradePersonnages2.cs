namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upgradePersonnages2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Personnages", "Hit", c => c.Int());
            AlterColumn("dbo.Personnages", "Hit2", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personnages", "Hit2", c => c.String());
            AlterColumn("dbo.Personnages", "Hit", c => c.String());
        }
    }
}

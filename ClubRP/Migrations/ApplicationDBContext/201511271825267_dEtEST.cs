namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dEtEST : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Test", c => c.Int(nullable: false));
        }
    }
}

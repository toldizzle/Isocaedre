namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Test", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Test");
        }
    }
}

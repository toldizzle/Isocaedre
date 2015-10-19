namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateDuMessageEtPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Creation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "DateMessage", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "DateMessage");
            DropColumn("dbo.Posts", "Creation");
        }
    }
}

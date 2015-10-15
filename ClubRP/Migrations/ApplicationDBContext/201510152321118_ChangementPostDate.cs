namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementPostDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Creation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Creation", c => c.DateTime(nullable: false));
        }
    }
}

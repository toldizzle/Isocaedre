namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InterfaceMOdification : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "NbReponse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "NbReponse", c => c.Int(nullable: false));
        }
    }
}

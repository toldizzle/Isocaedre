namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoueurRequireModif : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Joueurs", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Joueurs", "Nom", c => c.String(nullable: false));
        }
    }
}

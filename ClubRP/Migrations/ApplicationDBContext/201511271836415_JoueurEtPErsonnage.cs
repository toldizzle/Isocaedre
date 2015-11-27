namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoueurEtPErsonnage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Joueurs", "PersonnageID", c => c.Int(nullable: false));
            AlterColumn("dbo.Joueurs", "Nom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Joueurs", "Nom", c => c.String());
            DropColumn("dbo.Joueurs", "PersonnageID");
        }
    }
}

namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoueurMoinsCLasse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Joueurs", "Classe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Joueurs", "Classe", c => c.String());
        }
    }
}

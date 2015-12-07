namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upgradePersonnages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnages", "NomArme2", c => c.String());
            AddColumn("dbo.Personnages", "Degats2", c => c.String());
            AddColumn("dbo.Personnages", "Hit2", c => c.String());
            AddColumn("dbo.Personnages", "Crit2", c => c.String());
            AddColumn("dbo.Personnages", "Munition2", c => c.Int());
            AddColumn("dbo.Personnages", "DetailsArme2", c => c.String());
            AddColumn("dbo.Personnages", "NomBouclier", c => c.String());
            AddColumn("dbo.Personnages", "BouclierAC", c => c.Int());
            AddColumn("dbo.Personnages", "MalusBouclier", c => c.Int());
            AddColumn("dbo.Personnages", "DetailsBouclier", c => c.String());
            AlterColumn("dbo.Personnages", "NomPerso", c => c.String());
            AlterColumn("dbo.Personnages", "Race", c => c.String());
            AlterColumn("dbo.Personnages", "Classe", c => c.String());
            AlterColumn("dbo.Personnages", "Niveau", c => c.String());
            AlterColumn("dbo.Personnages", "VigueurBonus", c => c.Int());
            AlterColumn("dbo.Personnages", "VolonteBonus", c => c.Int());
            AlterColumn("dbo.Personnages", "ReflexeBonus", c => c.Int());
            AlterColumn("dbo.Personnages", "BaBBonus", c => c.Int());
            AlterColumn("dbo.Personnages", "InitiativeBonus", c => c.Int());
            AlterColumn("dbo.Personnages", "LutteBonus", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personnages", "LutteBonus", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnages", "InitiativeBonus", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnages", "BaBBonus", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnages", "ReflexeBonus", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnages", "VolonteBonus", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnages", "VigueurBonus", c => c.Int(nullable: false));
            AlterColumn("dbo.Personnages", "Niveau", c => c.String(nullable: false));
            AlterColumn("dbo.Personnages", "Classe", c => c.String(nullable: false));
            AlterColumn("dbo.Personnages", "Race", c => c.String(nullable: false));
            AlterColumn("dbo.Personnages", "NomPerso", c => c.String(nullable: false));
            DropColumn("dbo.Personnages", "DetailsBouclier");
            DropColumn("dbo.Personnages", "MalusBouclier");
            DropColumn("dbo.Personnages", "BouclierAC");
            DropColumn("dbo.Personnages", "NomBouclier");
            DropColumn("dbo.Personnages", "DetailsArme2");
            DropColumn("dbo.Personnages", "Munition2");
            DropColumn("dbo.Personnages", "Crit2");
            DropColumn("dbo.Personnages", "Hit2");
            DropColumn("dbo.Personnages", "Degats2");
            DropColumn("dbo.Personnages", "NomArme2");
        }
    }
}

namespace ClubRP.Migrations.ApplicationDBContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groupes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Description = c.String(),
                        Creation = c.DateTime(nullable: false),
                        AspNetUserID = c.String(),
                        Auteur = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Joueurs",
                c => new
                    {
                        JoueurID = c.Int(nullable: false, identity: true),
                        AspNetUserID = c.String(),
                        Nom = c.String(),
                        Maitre = c.Boolean(nullable: false),
                        Specialisation = c.String(),
                        GroupeID = c.Int(),
                        PersonnageID = c.Int(),
                    })
                .PrimaryKey(t => t.JoueurID)
                .ForeignKey("dbo.Groupes", t => t.GroupeID)
                .Index(t => t.GroupeID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        AspNetUserID = c.String(),
                        Auteur = c.String(),
                        Texte = c.String(),
                        DateMessage = c.DateTime(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Personnages",
                c => new
                    {
                        PersonnageID = c.Int(nullable: false, identity: true),
                        NomPerso = c.String(nullable: false),
                        Race = c.String(nullable: false),
                        Classe = c.String(nullable: false),
                        Niveau = c.String(nullable: false),
                        Alignement = c.String(),
                        Force = c.Int(nullable: false),
                        Dexterite = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        Charisme = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Sagesse = c.Int(nullable: false),
                        Vigueur = c.Int(nullable: false),
                        Volonte = c.Int(nullable: false),
                        Reflexe = c.Int(nullable: false),
                        VigueurBonus = c.Int(nullable: false),
                        VolonteBonus = c.Int(nullable: false),
                        ReflexeBonus = c.Int(nullable: false),
                        BaB = c.Int(nullable: false),
                        BaBBonus = c.Int(nullable: false),
                        Initiative = c.Int(nullable: false),
                        InitiativeBonus = c.Int(nullable: false),
                        Lutte = c.Int(nullable: false),
                        LutteBonus = c.Int(nullable: false),
                        HP = c.Int(nullable: false),
                        Deplacement = c.Int(nullable: false),
                        AC = c.Int(nullable: false),
                        NaturalAC = c.Int(),
                        ACBonus = c.Int(),
                        ResistanceSort = c.Int(),
                        ReductionDegat = c.Int(),
                        NomArme = c.String(),
                        Degats = c.String(),
                        Hit = c.String(),
                        Crit = c.String(),
                        Munition = c.Int(),
                        DetailsArme = c.String(),
                        NomArmure = c.String(),
                        ArmureAC = c.Int(),
                        TypeArmure = c.String(),
                        Malus = c.Int(),
                        DetailsArmure = c.String(),
                        Appraise = c.Int(),
                        Balance = c.Int(),
                        Bluff = c.Int(),
                        Climb = c.Int(),
                        Concentration = c.Int(),
                        Craft1 = c.Int(),
                        Craft1Nom = c.String(),
                        Craft2 = c.Int(),
                        Craft2Nom = c.String(),
                        Craft3 = c.Int(),
                        Craft3Nom = c.String(),
                        Decipher = c.Int(),
                        Diplomacy = c.Int(),
                        DisableDevice = c.Int(),
                        Disguise = c.Int(),
                        EscapeArtist = c.Int(),
                        Forgery = c.Int(),
                        GatherInfo = c.Int(),
                        HandleAnimal = c.Int(),
                        Heal = c.Int(),
                        Hide = c.Int(),
                        Intimidate = c.Int(),
                        Jump = c.Int(),
                        Knowledge1 = c.Int(),
                        Knowledge1Name = c.String(),
                        Knowledge2 = c.Int(),
                        Knowledge2Name = c.String(),
                        Knowledge3 = c.Int(),
                        Knowledge3Name = c.String(),
                        Knowledge4 = c.Int(),
                        Knowledge4Name = c.String(),
                        Knowledge5 = c.Int(),
                        Knowledge5Name = c.String(),
                        Listen = c.Int(),
                        MoveSilently = c.Int(),
                        OpenLock = c.Int(),
                        Perform1 = c.Int(),
                        Perform1Nom = c.String(),
                        Perform2 = c.Int(),
                        Perform2Nom = c.String(),
                        Profession1 = c.Int(),
                        Profession1Nom = c.String(),
                        Profession2 = c.Int(),
                        Profession2Nom = c.String(),
                        Ride = c.Int(),
                        Search = c.Int(),
                        SenseMotive = c.Int(),
                        SleightOfHand = c.Int(),
                        Spellcraft = c.Int(),
                        Spot = c.Int(),
                        Survival = c.Int(),
                        Swim = c.Int(),
                        Tumble = c.Int(),
                        UMD = c.Int(),
                        UseRope = c.Int(),
                        Notes = c.String(),
                        Gold = c.Int(),
                        Experience = c.Int(),
                        JoueurID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonnageID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titre = c.String(nullable: false),
                        Description = c.String(),
                        Creation = c.DateTime(nullable: false),
                        AspNetUserID = c.String(),
                        Auteur = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsersInfoSups",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Role = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        ImageNom = c.String(),
                        ImageType = c.String(),
                        ImageTaille = c.Int(nullable: false),
                        ImageData = c.Binary(),
                        Joueur_JoueurID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Joueurs", t => t.Joueur_JoueurID)
                .Index(t => t.Joueur_JoueurID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsersInfoSups", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.AspNetUsersInfoSups");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsersInfoSups", "Joueur_JoueurID", "dbo.Joueurs");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Joueurs", "GroupeID", "dbo.Groupes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetUsersInfoSups", new[] { "Joueur_JoueurID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "PostID" });
            DropIndex("dbo.Joueurs", new[] { "GroupeID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUsersInfoSups");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Posts");
            DropTable("dbo.Personnages");
            DropTable("dbo.Messages");
            DropTable("dbo.Joueurs");
            DropTable("dbo.Groupes");
        }
    }
}

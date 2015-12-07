namespace ClubRP.Migrations.ApplicationDBContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations\ApplicationDBContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            PasswordHasher pass = new PasswordHasher();

            AjouterUtilisateur(pass, context);
            AjouterRoles(context);
            AjouterUserRoles(context);
            AjoutPostEtMessage(context);
            AjouterGroupes(context);
            AjouterJoueurs(context);
            AjouterPersonnages(context);
        }

        private static void AjouterPersonnages(ApplicationDbContext context)
        {
            var userInit = (from user in context.Users
                            where user.UserName == "admin@isocaedre.ca"
                            select user).First();
            Personnage[] personnages = { new Personnage() {  AC=1, ACBonus=1, Alignement ="Neutre Bon", Appraise =1 , ArmureAC=2, BaB=3, BaBBonus=1, Balance=1, Bluff=1, BouclierAC=0, Charisme=11, Classe="Spicial", Climb=1, Concentration=2, Constitution=14, Craft1=2, Craft1Nom="Alchimie", Crit="19-20", Crit2="x2", Craft2=1, Craft2Nom="Forgeron", Craft3=2, Craft3Nom="Fermier", Decipher=1 , Degats="1d6", Degats2= "1d8", Deplacement=9, DetailsArme="Rien", DetailsArme2="Rien", DetailsArmure="Rien", DetailsBouclier="Rien", Dexterite=14, Diplomacy=3, DisableDevice=4, Disguise=3, EscapeArtist=1, Experience=3500, Force=16, Forgery=5, GatherInfo=4, Gold=100, HandleAnimal=3, Heal=4, Hide=4, Hit=5, Hit2=4, HP=20, Initiative=2, InitiativeBonus=2, Intelligence=12, Intimidate=3, Jump=2, Knowledge1=2, Knowledge1Name="Savoir 1", Knowledge2=3, Knowledge2Name="Savoir 2", Knowledge3=2, Knowledge3Name="Savoir 3", Knowledge4=3, Knowledge4Name="Savoir 4", Knowledge5=4, Knowledge5Name="Savoir 5", Listen=2, Lutte=2, LutteBonus=2, Malus=0, MalusBouclier=0, MoveSilently=2, Munition=0, Munition2=0, NaturalAC=2, Niveau="2", NomArme="Masse d'arme lourde", NomPerso="Toldizzle", NomArmure="Armure d'écaille", Notes="Aucune", OpenLock=3, Race="Humain", ReductionDegat=0, Reflexe=2, ReflexeBonus=2, ResistanceSort=0, Ride=2, Sagesse=19, Search=0, Spellcraft=9, TypeArmure="Intermédiaire", Vigueur=6, Volonte=6, VigueurBonus=2, VolonteBonus=2, JoueurID = 2 } };
            userInit.details.Joueur.Personnage = personnages[0];

            context.Personnages.AddOrUpdate(r => r.NomPerso, personnages);

            context.SaveChanges();
        }

        private static void AjoutPostEtMessage(ApplicationDbContext context)
        {
            var userInit = (from user in context.Users
                            where user.UserName == "admin@isocaedre.ca"
                            select user).First();
            context.Messages.AddOrUpdate(new Message
            {
                Texte = "Bienvenue sur notre forum, vous y retrouverez les mises à jour, ainsi que la liste des groupes de joueurs. Vous pouvez faire une petite présentation de vous ici et de vos attentes en temps que joueur."
                ,
                PostID = 1,
                MessageID = 1,
                DateMessage = DateTime.Now,
                AspNetUserID = userInit.Id,
                Auteur = userInit.UserName
            });
            context.Messages.AddOrUpdate(new Message
            {
                Texte = "Vous pouvez présenter votre scénario de groupe et recruter des joueurs ici!"
                ,
                PostID = 2,
                MessageID = 4,
                DateMessage = DateTime.Now,
                AspNetUserID = userInit.Id,
                Auteur = userInit.UserName
            });
            context.Posts.AddOrUpdate(new Post
            {
                Titre = "Introduction",
                Creation = DateTime.Now,
                ID = 1,
                Description = "Présentez-vous ici!",
                AspNetUserID = userInit.Id,
                Auteur = userInit.UserName
            });
            context.Posts.AddOrUpdate(new Post
            {
                Titre = "Création de groupe",
                Creation = DateTime.Now,
                ID = 2,
                Description = "Présentez votre scénario et recrutez des joueurs.",
                AspNetUserID = userInit.Id,
                Auteur = userInit.UserName
            });
            context.SaveChanges();
        }

        private static void AjouterUtilisateur(PasswordHasher pass, ApplicationDbContext context)
        {
            ApplicationUser[] users =
                        {
                new ApplicationUser
                {
                    Email = "admin@isocaedre.ca",
                    UserName = "admin@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Henry",
                        Prenom="Francis",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Administrateurs",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "maitre@isocaedre.ca",
                    UserName = "maitre@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Maitre123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Henry",
                        Prenom="Francis",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Maître",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "joueur@isocaedre.ca",
                    UserName = "joueur@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Joueur123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Défaut",
                        Prenom="Joueur",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Joueurs",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "moderateur@isocaedre.ca",
                    UserName = "moderateur@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Moderateur123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Henry",
                        Prenom="Francis",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "Modérateurs",
                        Fichier = null
                    }
                },
                new ApplicationUser
                {
                    Email = "exclus@isocaedre.ca",
                    UserName = "exclus@isocaedre.ca",
                    PasswordHash = pass.HashPassword("Exclus123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUsersInfoSup
                    {
                        Nom="Rejet",
                        Prenom="Forum",
                        ImageData= new byte[0],
                        ImageNom = "",
                        ImageTaille = 0,
                        ImageType = "",
                        Role = "ExclusionForum",
                        Fichier = null
                    }
                }
            };
            //Ajouter un id dans chacune des tables / details et user
            foreach (ApplicationUser u in users)
            {
                u.details.ID = u.Id;
            }

            context.Users.AddOrUpdate(u => u.UserName, users);
            context.SaveChanges();
        }

        private static void AjouterUserRoles(ApplicationDbContext context)
        {
            IdentityUserRole[] userroles =
                        {
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "admin@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Administrateurs").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "moderateur@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Modérateurs").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "joueur@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Joueurs").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "maitre@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Maîtres").First().Id
                },
                new IdentityUserRole
                {
                    UserId = context.Users.Where(u => u.UserName == "exclus@isocaedre.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "ExclusionForum").First().Id
                }
            };
            context.Set<IdentityUserRole>().AddOrUpdate(ur => new { ur.UserId, ur.RoleId }, userroles);
            context.SaveChanges();
        }

        private static void AjouterRoles(ApplicationDbContext context)
        {
            IdentityRole[] roles =
                        {
                    new IdentityRole() {Name = "Administrateurs" },
                    new IdentityRole() { Name = "Utilisateurs" },
                    new IdentityRole() { Name = "Modérateurs" },
                    new IdentityRole() { Name = "ExclusionForum" },
                    new IdentityRole() { Name = "Maîtres" },
                    new IdentityRole() { Name = "Joueurs" }
            };
            context.Roles.AddOrUpdate(r => r.Name, roles);
            context.SaveChanges();
        }
        private static void AjouterGroupes(ApplicationDbContext context)
        {
            var userInit = (from user in context.Users
                            where user.UserName == "admin@isocaedre.ca"
                            select user).First();

            Groupe[] groupe = { new Groupe() { AspNetUserID = userInit.Id, Auteur = "admin@isocaedre.ca", Creation = DateTime.Now, Description = "Voici une idée de création de groupe", Titre = "Toldoth" } };
            context.Groupes.AddOrUpdate(r => r.Titre, groupe);
            context.SaveChanges();
        }
        private static void AjouterJoueurs(ApplicationDbContext context)
        {
            var userInit = (from user in context.Users
                            where user.UserName == "admin@isocaedre.ca"
                            select user).First();
            Joueur[] joueurs = { new Joueur() { AspNetUserID = userInit.Id, GroupeID = context.Groupes.First().ID, Maitre = true, Nom = userInit.UserName, Specialisation = "DPS", JoueurID=2} };
            userInit.details.Joueur = joueurs[0];

            context.Joueurs.AddOrUpdate(r => r.Nom, joueurs);
            
            context.SaveChanges();
        }
    }
}
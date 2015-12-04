
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2015 12:38:41
-- Generated from EDMX file: C:\Session3\ApplicationWeb\Projet\Isocaedre\ClubRP\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ApplicationDbContext];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetRoles_RoleId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo_AspNetUserRoles_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUsers_dbo_AspNetUsersInfoSups_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [FK_dbo_AspNetUsers_dbo_AspNetUsersInfoSups_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUsersInfoSups_dbo_Joueurs_Joueur_JoueurID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsersInfoSups] DROP CONSTRAINT [FK_dbo_AspNetUsersInfoSups_dbo_Joueurs_Joueur_JoueurID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Joueurs_dbo_Groupes_GroupeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Joueurs] DROP CONSTRAINT [FK_dbo_Joueurs_dbo_Groupes_GroupeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Messages_dbo_Posts_PostID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_dbo_Messages_dbo_Posts_PostID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsersInfoSups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsersInfoSups];
GO
IF OBJECT_ID(N'[dbo].[Groupes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groupes];
GO
IF OBJECT_ID(N'[dbo].[Joueurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Joueurs];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Personnages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personnages];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUsersInfoSups'
CREATE TABLE [dbo].[AspNetUsersInfoSups] (
    [ID] nvarchar(128)  NOT NULL,
    [Role] nvarchar(max)  NULL,
    [Nom] nvarchar(max)  NULL,
    [Prenom] nvarchar(max)  NULL,
    [ImageNom] nvarchar(max)  NULL,
    [ImageType] nvarchar(max)  NULL,
    [ImageTaille] int  NOT NULL,
    [ImageData] varbinary(max)  NULL,
    [Joueur_JoueurID] int  NULL
);
GO

-- Creating table 'Groupes'
CREATE TABLE [dbo].[Groupes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Creation] datetime  NOT NULL,
    [AspNetUserID] nvarchar(max)  NULL,
    [Auteur] nvarchar(max)  NULL
);
GO

-- Creating table 'Joueurs'
CREATE TABLE [dbo].[Joueurs] (
    [JoueurID] int IDENTITY(1,1) NOT NULL,
    [AspNetUserID] nvarchar(max)  NULL,
    [Nom] nvarchar(max)  NULL,
    [Maitre] bit  NOT NULL,
    [Specialisation] nvarchar(max)  NULL,
    [GroupeID] int  NULL,
    [PersonnageID] int  NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageID] int IDENTITY(1,1) NOT NULL,
    [AspNetUserID] nvarchar(max)  NULL,
    [Auteur] nvarchar(max)  NULL,
    [Texte] nvarchar(max)  NULL,
    [DateMessage] datetime  NOT NULL,
    [PostID] int  NOT NULL
);
GO

-- Creating table 'Personnages'
CREATE TABLE [dbo].[Personnages] (
    [PersonnageID] int IDENTITY(1,1) NOT NULL,
    [NomPerso] nvarchar(max)  NOT NULL,
    [Race] nvarchar(max)  NOT NULL,
    [Classe] nvarchar(max)  NOT NULL,
    [Niveau] nvarchar(max)  NOT NULL,
    [Alignement] nvarchar(max)  NULL,
    [Force] int  NOT NULL,
    [Dexterite] int  NOT NULL,
    [Constitution] int  NOT NULL,
    [Charisme] int  NOT NULL,
    [Intelligence] int  NOT NULL,
    [Sagesse] int  NOT NULL,
    [Vigueur] int  NOT NULL,
    [Volonte] int  NOT NULL,
    [Reflexe] int  NOT NULL,
    [VigueurBonus] int  NOT NULL,
    [VolonteBonus] int  NOT NULL,
    [ReflexeBonus] int  NOT NULL,
    [BaB] int  NOT NULL,
    [BaBBonus] int  NOT NULL,
    [Initiative] int  NOT NULL,
    [InitiativeBonus] int  NOT NULL,
    [Lutte] int  NOT NULL,
    [LutteBonus] int  NOT NULL,
    [HP] int  NOT NULL,
    [Deplacement] int  NOT NULL,
    [AC] int  NOT NULL,
    [NaturalAC] int  NULL,
    [ACBonus] int  NULL,
    [ResistanceSort] int  NULL,
    [ReductionDegat] int  NULL,
    [NomArme] nvarchar(max)  NULL,
    [Degats] nvarchar(max)  NULL,
    [Hit] nvarchar(max)  NULL,
    [Crit] nvarchar(max)  NULL,
    [Munition] int  NULL,
    [DetailsArme] nvarchar(max)  NULL,
    [NomArmure] nvarchar(max)  NULL,
    [ArmureAC] int  NULL,
    [TypeArmure] nvarchar(max)  NULL,
    [Malus] int  NULL,
    [DetailsArmure] nvarchar(max)  NULL,
    [Appraise] int  NULL,
    [Balance] int  NULL,
    [Bluff] int  NULL,
    [Climb] int  NULL,
    [Concentration] int  NULL,
    [Craft1] int  NULL,
    [Craft1Nom] nvarchar(max)  NULL,
    [Craft2] int  NULL,
    [Craft2Nom] nvarchar(max)  NULL,
    [Craft3] int  NULL,
    [Craft3Nom] nvarchar(max)  NULL,
    [Decipher] int  NULL,
    [Diplomacy] int  NULL,
    [DisableDevice] int  NULL,
    [Disguise] int  NULL,
    [EscapeArtist] int  NULL,
    [Forgery] int  NULL,
    [GatherInfo] int  NULL,
    [HandleAnimal] int  NULL,
    [Heal] int  NULL,
    [Hide] int  NULL,
    [Intimidate] int  NULL,
    [Jump] int  NULL,
    [Knowledge1] int  NULL,
    [Knowledge1Name] nvarchar(max)  NULL,
    [Knowledge2] int  NULL,
    [Knowledge2Name] nvarchar(max)  NULL,
    [Knowledge3] int  NULL,
    [Knowledge3Name] nvarchar(max)  NULL,
    [Knowledge4] int  NULL,
    [Knowledge4Name] nvarchar(max)  NULL,
    [Knowledge5] int  NULL,
    [Knowledge5Name] nvarchar(max)  NULL,
    [Listen] int  NULL,
    [MoveSilently] int  NULL,
    [OpenLock] int  NULL,
    [Perform1] int  NULL,
    [Perform1Nom] nvarchar(max)  NULL,
    [Perform2] int  NULL,
    [Perform2Nom] nvarchar(max)  NULL,
    [Profession1] int  NULL,
    [Profession1Nom] nvarchar(max)  NULL,
    [Profession2] int  NULL,
    [Profession2Nom] nvarchar(max)  NULL,
    [Ride] int  NULL,
    [Search] int  NULL,
    [SenseMotive] int  NULL,
    [SleightOfHand] int  NULL,
    [Spellcraft] int  NULL,
    [Spot] int  NULL,
    [Survival] int  NULL,
    [Swim] int  NULL,
    [Tumble] int  NULL,
    [UMD] int  NULL,
    [UseRope] int  NULL,
    [Notes] nvarchar(max)  NULL,
    [Gold] int  NULL,
    [Experience] int  NULL,
    [JoueurID] int  NOT NULL,
    [Joueurs_JoueurID] int  NOT NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Creation] datetime  NOT NULL,
    [AspNetUserID] nvarchar(max)  NULL,
    [Auteur] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'AspNetUsersInfoSups'
ALTER TABLE [dbo].[AspNetUsersInfoSups]
ADD CONSTRAINT [PK_AspNetUsersInfoSups]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Groupes'
ALTER TABLE [dbo].[Groupes]
ADD CONSTRAINT [PK_Groupes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [JoueurID] in table 'Joueurs'
ALTER TABLE [dbo].[Joueurs]
ADD CONSTRAINT [PK_Joueurs]
    PRIMARY KEY CLUSTERED ([JoueurID] ASC);
GO

-- Creating primary key on [MessageID] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageID] ASC);
GO

-- Creating primary key on [PersonnageID] in table 'Personnages'
ALTER TABLE [dbo].[Personnages]
ADD CONSTRAINT [PK_Personnages]
    PRIMARY KEY CLUSTERED ([PersonnageID] ASC);
GO

-- Creating primary key on [ID] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [FK_dbo_AspNetUsers_dbo_AspNetUsersInfoSups_Id]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[AspNetUsersInfoSups]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Joueur_JoueurID] in table 'AspNetUsersInfoSups'
ALTER TABLE [dbo].[AspNetUsersInfoSups]
ADD CONSTRAINT [FK_dbo_AspNetUsersInfoSups_dbo_Joueurs_Joueur_JoueurID]
    FOREIGN KEY ([Joueur_JoueurID])
    REFERENCES [dbo].[Joueurs]
        ([JoueurID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUsersInfoSups_dbo_Joueurs_Joueur_JoueurID'
CREATE INDEX [IX_FK_dbo_AspNetUsersInfoSups_dbo_Joueurs_Joueur_JoueurID]
ON [dbo].[AspNetUsersInfoSups]
    ([Joueur_JoueurID]);
GO

-- Creating foreign key on [GroupeID] in table 'Joueurs'
ALTER TABLE [dbo].[Joueurs]
ADD CONSTRAINT [FK_dbo_Joueurs_dbo_Groupes_GroupeID]
    FOREIGN KEY ([GroupeID])
    REFERENCES [dbo].[Groupes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Joueurs_dbo_Groupes_GroupeID'
CREATE INDEX [IX_FK_dbo_Joueurs_dbo_Groupes_GroupeID]
ON [dbo].[Joueurs]
    ([GroupeID]);
GO

-- Creating foreign key on [PostID] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_dbo_Messages_dbo_Posts_PostID]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[Posts]
        ([ID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Messages_dbo_Posts_PostID'
CREATE INDEX [IX_FK_dbo_Messages_dbo_Posts_PostID]
ON [dbo].[Messages]
    ([PostID]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [Joueurs_JoueurID] in table 'Personnages'
ALTER TABLE [dbo].[Personnages]
ADD CONSTRAINT [FK_PersonnagesJoueurs]
    FOREIGN KEY ([Joueurs_JoueurID])
    REFERENCES [dbo].[Joueurs]
        ([JoueurID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonnagesJoueurs'
CREATE INDEX [IX_FK_PersonnagesJoueurs]
ON [dbo].[Personnages]
    ([Joueurs_JoueurID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
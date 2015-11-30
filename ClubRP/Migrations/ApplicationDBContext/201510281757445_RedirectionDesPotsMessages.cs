namespace ClubRP.Migrations.ApplicationDBContext
{
    using System.Data.Entity.Migrations;

    public partial class RedirectionDesPotsMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                {
                    MessageID = c.Int(nullable: false, identity: true),
                    AuteurMessage = c.String(),
                    Texte = c.String(),
                    DateMessage = c.DateTime(nullable: false),
                    PostID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Titre = c.String(nullable: false),
                    Description = c.String(),
                    Creation = c.DateTime(nullable: false),
                    Auteur = c.String(),
                })
                .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Messages", "PostID", "dbo.Posts");
            DropIndex("dbo.Messages", new[] { "PostID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
        }
    }
}
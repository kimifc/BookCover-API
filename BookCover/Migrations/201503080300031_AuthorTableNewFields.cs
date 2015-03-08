namespace BookCover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorTableNewFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Title = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorID)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            AddColumn("dbo.Books", "SubInfo", c => c.String());
            DropColumn("dbo.Books", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Url", c => c.String());
            DropForeignKey("dbo.Authors", "BookId", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "BookId" });
            DropColumn("dbo.Books", "SubInfo");
            DropTable("dbo.Authors");
        }
    }
}

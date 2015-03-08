namespace BookCover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        SubTitle = c.String(),
                        Edition = c.String(),
                        ExtraInfo = c.String(),
                        BrandImage = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.KeyPoints",
                c => new
                    {
                        KeyPointID = c.Int(nullable: false, identity: true),
                        KeyPointInfo = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyPointID)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KeyPoints", "BookId", "dbo.Books");
            DropIndex("dbo.KeyPoints", new[] { "BookId" });
            DropTable("dbo.KeyPoints");
            DropTable("dbo.Books");
        }
    }
}

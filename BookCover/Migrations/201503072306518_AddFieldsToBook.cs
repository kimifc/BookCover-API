namespace BookCover.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "HighlightInfo", c => c.String());
            AddColumn("dbo.Books", "SpecialOfferInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "SpecialOfferInfo");
            DropColumn("dbo.Books", "HighlightInfo");
        }
    }
}

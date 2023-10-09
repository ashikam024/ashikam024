namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
            AddColumn("dbo.Products", "Size", c => c.String());
            AddColumn("dbo.Products", "Colour", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Colour");
            DropColumn("dbo.Products", "Size");
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}

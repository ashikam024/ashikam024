namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availabilitymigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Availability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Availability");
        }
    }
}

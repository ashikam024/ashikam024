namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcartitems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartItems", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CartItems", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "Total");
            DropColumn("dbo.CartItems", "SubTotal");
            DropColumn("dbo.CartItems", "Price");
        }
    }
}

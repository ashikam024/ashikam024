namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedcartitem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "Size", c => c.String());
            DropColumn("dbo.CartItems", "SubTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CartItems", "Size");
        }
    }
}

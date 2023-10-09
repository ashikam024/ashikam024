namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcartitems2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "ImageUrl");
        }
    }
}

namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderModelRepaired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Orders", new[] { "Card_Id" });
            AddColumn("dbo.Orders", "UserName", c => c.String());
            DropColumn("dbo.Orders", "ProductImage");
            DropColumn("dbo.Orders", "SubTotal");
            DropColumn("dbo.Orders", "ShippingAddress");
            DropColumn("dbo.Orders", "BillingInformation");
            DropColumn("dbo.Orders", "PaymentMethod");
            DropColumn("dbo.Orders", "CardNumber");
            DropColumn("dbo.Orders", "CVV");
            DropColumn("dbo.Orders", "Card_Id");
            DropTable("dbo.Cards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CardNumber = c.Double(nullable: false),
                        CVV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Card_Id", c => c.Int());
            AddColumn("dbo.Orders", "CVV", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CardNumber", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "PaymentMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "BillingInformation", c => c.String());
            AddColumn("dbo.Orders", "ShippingAddress", c => c.String());
            AddColumn("dbo.Orders", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ProductImage", c => c.String());
            DropColumn("dbo.Orders", "UserName");
            CreateIndex("dbo.Orders", "Card_Id");
            AddForeignKey("dbo.Orders", "Card_Id", "dbo.Cards", "Id");
        }
    }
}

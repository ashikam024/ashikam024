namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repair : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShipmentModels", "PaymentType_Id", "dbo.Payments");
            DropIndex("dbo.ShipmentModels", new[] { "PaymentType_Id" });
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
            
            AddColumn("dbo.Orders", "ProductImage", c => c.String());
            AddColumn("dbo.Orders", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "ShippingAddress", c => c.String());
            AddColumn("dbo.Orders", "BillingInformation", c => c.String());
            AddColumn("dbo.Orders", "PaymentMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CardNumber", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "CVV", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Card_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Card_Id");
            AddForeignKey("dbo.Orders", "Card_Id", "dbo.Cards", "Id");
            DropColumn("dbo.Orders", "UserName");
            DropTable("dbo.Payments");
            DropTable("dbo.ShipmentModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShipmentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PaymentType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "UserName", c => c.String());
            DropForeignKey("dbo.Orders", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Orders", new[] { "Card_Id" });
            DropColumn("dbo.Orders", "Card_Id");
            DropColumn("dbo.Orders", "CVV");
            DropColumn("dbo.Orders", "CardNumber");
            DropColumn("dbo.Orders", "PaymentMethod");
            DropColumn("dbo.Orders", "BillingInformation");
            DropColumn("dbo.Orders", "ShippingAddress");
            DropColumn("dbo.Orders", "SubTotal");
            DropColumn("dbo.Orders", "ProductImage");
            DropTable("dbo.Cards");
            CreateIndex("dbo.ShipmentModels", "PaymentType_Id");
            AddForeignKey("dbo.ShipmentModels", "PaymentType_Id", "dbo.Payments", "Id");
        }
    }
}

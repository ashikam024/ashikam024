namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cardfetails : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Orders", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ProductImage", c => c.String());
            AddColumn("dbo.Orders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "SubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "PaymentMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CardNumber", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "CVV", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Card_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Card_Id");
            AddForeignKey("dbo.Orders", "Card_Id", "dbo.Cards", "Id");
            DropColumn("dbo.Orders", "OrderDate");
            DropColumn("dbo.Orders", "PaymentStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "PaymentStatus", c => c.String());
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Orders", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Orders", new[] { "Card_Id" });
            DropColumn("dbo.Orders", "Card_Id");
            DropColumn("dbo.Orders", "CVV");
            DropColumn("dbo.Orders", "CardNumber");
            DropColumn("dbo.Orders", "PaymentMethod");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "SubTotal");
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "Price");
            DropColumn("dbo.Orders", "ProductImage");
            DropColumn("dbo.Orders", "ProductId");
            DropTable("dbo.Cards");
        }
    }
}

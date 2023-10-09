namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cateidmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Categoryname", c => c.String());
            AddColumn("dbo.Products", "catogoryid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "catogoryid");
            DropColumn("dbo.Products", "Categoryname");
        }
    }
}

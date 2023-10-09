namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeuserid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartItems", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "UserId", c => c.Int(nullable: false));
        }
    }
}

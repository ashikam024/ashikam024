namespace ECommerceProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "UserId");
        }
    }
}

namespace Hammers.Inventory.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WithInitialData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.Int(nullable: false));
        }
    }
}

namespace EquineElegance.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDoubleToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blankets", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Caps", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Feeders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RidingPants", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SaddlePads", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.TackRooms", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TackRooms", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.SaddlePads", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.RidingPants", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Feeders", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Caps", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Blankets", "Price", c => c.Double(nullable: false));
        }
    }
}

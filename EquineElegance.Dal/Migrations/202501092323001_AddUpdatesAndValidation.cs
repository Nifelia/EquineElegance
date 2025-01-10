namespace EquineElegance.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatesAndValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feeders", "Capacity", c => c.String(nullable: false));
            AlterColumn("dbo.Feeders", "Dimensions", c => c.String(nullable: false));
            AlterColumn("dbo.TackRooms", "Dimensions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TackRooms", "Dimensions", c => c.String());
            AlterColumn("dbo.Feeders", "Dimensions", c => c.String());
            AlterColumn("dbo.Feeders", "Capacity", c => c.String());
        }
    }
}

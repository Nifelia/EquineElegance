namespace EquineElegance.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCapValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blankets", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Blankets", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Blankets", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Caps", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Caps", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Caps", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Feeders", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Feeders", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Feeders", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.RidingPants", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.RidingPants", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.RidingPants", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.SaddlePads", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SaddlePads", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.SaddlePads", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.TackRooms", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.TackRooms", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.TackRooms", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TackRooms", "Image", c => c.String());
            AlterColumn("dbo.TackRooms", "Description", c => c.String());
            AlterColumn("dbo.TackRooms", "Name", c => c.String());
            AlterColumn("dbo.SaddlePads", "Image", c => c.String());
            AlterColumn("dbo.SaddlePads", "Description", c => c.String());
            AlterColumn("dbo.SaddlePads", "Name", c => c.String());
            AlterColumn("dbo.RidingPants", "Image", c => c.String());
            AlterColumn("dbo.RidingPants", "Description", c => c.String());
            AlterColumn("dbo.RidingPants", "Name", c => c.String());
            AlterColumn("dbo.Feeders", "Image", c => c.String());
            AlterColumn("dbo.Feeders", "Description", c => c.String());
            AlterColumn("dbo.Feeders", "Name", c => c.String());
            AlterColumn("dbo.Caps", "Image", c => c.String());
            AlterColumn("dbo.Caps", "Description", c => c.String());
            AlterColumn("dbo.Caps", "Name", c => c.String());
            AlterColumn("dbo.Blankets", "Image", c => c.String());
            AlterColumn("dbo.Blankets", "Description", c => c.String());
            AlterColumn("dbo.Blankets", "Name", c => c.String());
        }
    }
}

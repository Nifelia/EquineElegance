namespace EquineElegance.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blankets",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        BlanketType = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        HorseSize = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Caps",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        CapSize = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Feeders",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Capacity = c.String(),
                        Dimensions = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.RidingPants",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Gender = c.Int(nullable: false),
                        PantsSize = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.SaddlePads",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        SaddlePadType = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        HorseSize = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.TackRooms",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        TackRoomHangerType = c.Int(nullable: false),
                        Dimensions = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Image = c.String(),
                        AmountInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TackRooms");
            DropTable("dbo.SaddlePads");
            DropTable("dbo.RidingPants");
            DropTable("dbo.Feeders");
            DropTable("dbo.Caps");
            DropTable("dbo.Blankets");
        }
    }
}

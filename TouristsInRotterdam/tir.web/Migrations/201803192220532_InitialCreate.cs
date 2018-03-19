namespace TouristsInRotterdam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PointOfInterests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        PointOfInterestType = c.Int(nullable: false),
                        lon = c.Double(nullable: false),
                        lat = c.Double(nullable: false),
                        address = c.String(),
                        zipcode = c.String(),
                        town = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        operator_id = c.String(),
                        name = c.String(),
                        town = c.String(),
                        lon = c.Double(nullable: false),
                        lat = c.Double(nullable: false),
                        StationType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stations");
            DropTable("dbo.PointOfInterests");
        }
    }
}

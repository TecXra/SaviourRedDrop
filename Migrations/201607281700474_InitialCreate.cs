namespace SaviourRedDrop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BloodGroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FeedBack = c.String(),
                        writerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SaviourRDUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SaviourRDUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        ReviewStatus = c.Int(nullable: false),
                        BGId = c.Int(nullable: false),
                        Area = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BloodGroups", t => t.BGId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.Area, cascadeDelete: true)
                .Index(t => t.BGId)
                .Index(t => t.Area);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UserId", "dbo.SaviourRDUsers");
            DropForeignKey("dbo.SaviourRDUsers", "Area", "dbo.Cities");
            DropForeignKey("dbo.SaviourRDUsers", "BGId", "dbo.BloodGroups");
            DropIndex("dbo.SaviourRDUsers", new[] { "Area" });
            DropIndex("dbo.SaviourRDUsers", new[] { "BGId" });
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropTable("dbo.SaviourRDUsers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Cities");
            DropTable("dbo.BloodGroups");
        }
    }
}

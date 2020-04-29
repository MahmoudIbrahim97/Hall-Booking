namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyBookingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        Services = c.String(),
                        Notes = c.String(),
                        UserId = c.String(),
                        HallId = c.Int(nullable: false),
                        MyUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.MyUser_Id)
                .Index(t => t.HallId)
                .Index(t => t.MyUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyBookings", "MyUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MyBookings", "HallId", "dbo.Halls");
            DropIndex("dbo.MyBookings", new[] { "MyUser_Id" });
            DropIndex("dbo.MyBookings", new[] { "HallId" });
            DropTable("dbo.MyBookings");
        }
    }
}

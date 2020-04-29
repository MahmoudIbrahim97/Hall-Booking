namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyBookings", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.MyBookings", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyBookings", "EndTime", c => c.String(nullable: false));
            AlterColumn("dbo.MyBookings", "StartTime", c => c.String(nullable: false));
        }
    }
}

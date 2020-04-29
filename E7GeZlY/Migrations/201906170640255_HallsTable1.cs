namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HallsTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Halls", "AdditionalService", c => c.String());
            AlterColumn("dbo.Halls", "Service2", c => c.String());
            AlterColumn("dbo.Halls", "Service3", c => c.String());
            AlterColumn("dbo.Halls", "Service4", c => c.String());
            AlterColumn("dbo.Halls", "Service5", c => c.String());
            AlterColumn("dbo.Halls", "Service6", c => c.String());
            AlterColumn("dbo.Halls", "Service7", c => c.String());
            AlterColumn("dbo.Halls", "Service8", c => c.String());
            AlterColumn("dbo.Halls", "Service9", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Halls", "Service9", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service8", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service7", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service6", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service5", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service4", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service3", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "Service2", c => c.String(nullable: false));
            AlterColumn("dbo.Halls", "AdditionalService", c => c.String(nullable: false));
        }
    }
}

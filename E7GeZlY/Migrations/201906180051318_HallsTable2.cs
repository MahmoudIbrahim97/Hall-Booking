namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HallsTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Halls", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Halls", "Image", c => c.String(nullable: false));
        }
    }
}

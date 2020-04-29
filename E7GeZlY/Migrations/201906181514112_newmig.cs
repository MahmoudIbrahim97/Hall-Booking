namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Halls", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Halls", "UserId");
        }
    }
}

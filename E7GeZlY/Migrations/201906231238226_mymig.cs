namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Halls", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Halls", "UserId");
            AddForeignKey("dbo.Halls", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Halls", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Halls", new[] { "UserId" });
            AlterColumn("dbo.Halls", "UserId", c => c.String());
        }
    }
}

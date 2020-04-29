namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HallsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HallName = c.String(nullable: false),
                        License = c.String(nullable: false),
                        County = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Services = c.String(nullable: false),
                        AdditionalService = c.String(nullable: false),
                        Service2 = c.String(nullable: false),
                        Service3 = c.String(nullable: false),
                        Service4 = c.String(nullable: false),
                        Service5 = c.String(nullable: false),
                        Service6 = c.String(nullable: false),
                        Service7 = c.String(nullable: false),
                        Service8 = c.String(nullable: false),
                        Service9 = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Halls", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Halls", new[] { "CategoryId" });
            DropTable("dbo.Halls");
        }
    }
}

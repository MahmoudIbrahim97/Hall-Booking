namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoleViewModels", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoleViewModels", "Name", c => c.String());
        }
    }
}

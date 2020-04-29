namespace E7GeZlY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserType");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}

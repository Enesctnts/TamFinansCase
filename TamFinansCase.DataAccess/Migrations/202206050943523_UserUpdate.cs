namespace TamFinansCase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

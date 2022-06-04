namespace TamFinansCase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoringg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "BookStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "IsDeleted");
        }
    }
}

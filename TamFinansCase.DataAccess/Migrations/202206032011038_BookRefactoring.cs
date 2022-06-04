namespace TamFinansCase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookRefactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Books", "BookStatus");
        }
    }
}

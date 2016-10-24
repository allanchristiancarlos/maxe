namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Required", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Required");
        }
    }
}

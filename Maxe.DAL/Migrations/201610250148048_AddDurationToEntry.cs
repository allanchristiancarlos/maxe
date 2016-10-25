namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationToEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "DurationInMinutes", c => c.Int());
            AlterColumn("dbo.Entries", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Entries", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Entries", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Entries", "DurationInMinutes");
        }
    }
}

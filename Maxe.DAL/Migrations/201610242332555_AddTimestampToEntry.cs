namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimestampToEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("dbo.Entries", "SubmittedAt", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "SubmittedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Entries", "TimeStamp");
        }
    }
}

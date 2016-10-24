namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoTimeStampForEntries : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "SubmittedAt", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "SubmittedAt", c => c.DateTime());
        }
    }
}

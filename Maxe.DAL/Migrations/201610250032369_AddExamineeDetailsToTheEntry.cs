namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamineeDetailsToTheEntry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "ExamineeId", "dbo.Examinees");
            DropIndex("dbo.Entries", new[] { "ExamineeId" });
            AddColumn("dbo.Entries", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Entries", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Entries", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Entries", "Position", c => c.String(nullable: false));
            AddColumn("dbo.Entries", "MobileNumber", c => c.String(nullable: false));
            AddColumn("dbo.Entries", "Address", c => c.String());
            AlterColumn("dbo.Entries", "SubmittedAt", c => c.DateTime(defaultValueSql: "GETUTCDATE()"));
            DropColumn("dbo.Entries", "ExamineeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "ExamineeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "SubmittedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Entries", "Address");
            DropColumn("dbo.Entries", "MobileNumber");
            DropColumn("dbo.Entries", "Position");
            DropColumn("dbo.Entries", "Email");
            DropColumn("dbo.Entries", "LastName");
            DropColumn("dbo.Entries", "FirstName");
            CreateIndex("dbo.Entries", "ExamineeId");
            AddForeignKey("dbo.Entries", "ExamineeId", "dbo.Examinees", "ExamineeId", cascadeDelete: true);
        }
    }
}

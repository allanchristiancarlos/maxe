namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExamIdToEntries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "ExamId", c => c.Int());
            CreateIndex("dbo.Entries", "ExamId");
            AddForeignKey("dbo.Entries", "ExamId", "dbo.Exams", "ExamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "ExamId", "dbo.Exams");
            DropIndex("dbo.Entries", new[] { "ExamId" });
            DropColumn("dbo.Entries", "ExamId");
        }
    }
}

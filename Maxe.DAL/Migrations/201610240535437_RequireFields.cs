namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnswerItems", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.Entries", "ExamId", "dbo.Exams");
            DropIndex("dbo.AnswerItems", new[] { "AnswerId" });
            DropIndex("dbo.Entries", new[] { "ExamId" });
            AddColumn("dbo.Answers", "NumberValue", c => c.Int(nullable: true));
            AddColumn("dbo.Answers", "StringValue", c => c.String(nullable: true));
            AddColumn("dbo.AnswerItems", "NumberValue", c => c.Int(nullable: true));
            AddColumn("dbo.AnswerItems", "StringValue", c => c.String(nullable: true));
            AlterColumn("dbo.AnswerItems", "AnswerId", c => c.Int());
            AlterColumn("dbo.Entries", "ExamId", c => c.Int(nullable: false));
            CreateIndex("dbo.AnswerItems", "AnswerId");
            CreateIndex("dbo.Entries", "ExamId");
            AddForeignKey("dbo.AnswerItems", "AnswerId", "dbo.Answers", "AnswerId");
            AddForeignKey("dbo.Entries", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: false);
            DropColumn("dbo.Answers", "AnswerNumberValue");
            DropColumn("dbo.Answers", "AnswerStringValue");
            DropColumn("dbo.AnswerItems", "ItemNumberValue");
            DropColumn("dbo.AnswerItems", "ItemStringValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AnswerItems", "ItemStringValue", c => c.String());
            AddColumn("dbo.AnswerItems", "ItemNumberValue", c => c.String());
            AddColumn("dbo.Answers", "AnswerStringValue", c => c.String());
            AddColumn("dbo.Answers", "AnswerNumberValue", c => c.String());
            DropForeignKey("dbo.Entries", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.AnswerItems", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Entries", new[] { "ExamId" });
            DropIndex("dbo.AnswerItems", new[] { "AnswerId" });
            AlterColumn("dbo.Entries", "ExamId", c => c.Int());
            AlterColumn("dbo.AnswerItems", "AnswerId", c => c.Int(nullable: false));
            DropColumn("dbo.AnswerItems", "StringValue");
            DropColumn("dbo.AnswerItems", "NumberValue");
            DropColumn("dbo.Answers", "StringValue");
            DropColumn("dbo.Answers", "NumberValue");
            CreateIndex("dbo.Entries", "ExamId");
            CreateIndex("dbo.AnswerItems", "AnswerId");
            AddForeignKey("dbo.Entries", "ExamId", "dbo.Exams", "ExamId");
            AddForeignKey("dbo.AnswerItems", "AnswerId", "dbo.Answers", "AnswerId", cascadeDelete: true);
        }
    }
}

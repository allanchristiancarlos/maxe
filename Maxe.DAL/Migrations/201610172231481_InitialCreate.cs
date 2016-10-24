namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        AnswerValue = c.String(),
                        QuestionId = c.Int(nullable: false),
                        EntryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Entries", t => t.EntryId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.EntryId);
            
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        SubmittedAt = c.DateTime(nullable: false),
                        ExamineeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Examinees", t => t.ExamineeId, cascadeDelete: true)
                .Index(t => t.ExamineeId);
            
            CreateTable(
                "dbo.Examinees",
                c => new
                    {
                        ExamineeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.ExamineeId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Examinee_ExamineeId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamId)
                .ForeignKey("dbo.Examinees", t => t.Examinee_ExamineeId)
                .Index(t => t.Examinee_ExamineeId);
            
            CreateTable(
                "dbo.ExamSections",
                c => new
                    {
                        ExamSectionId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ExamId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamSectionId)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        RightAnswer = c.String(),
                        Order = c.Int(nullable: false),
                        QuestionTypeId = c.Int(nullable: false),
                        ExamSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.ExamSections", t => t.ExamSectionId, cascadeDelete: true)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, cascadeDelete: true)
                .Index(t => t.QuestionTypeId)
                .Index(t => t.ExamSectionId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QuestionTypeId = c.Int(nullable: false, identity: true),
                        FriendlyName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        QuestionChoiceId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        ChoiceValue = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionChoiceId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "EntryId", "dbo.Entries");
            DropForeignKey("dbo.Entries", "ExamineeId", "dbo.Examinees");
            DropForeignKey("dbo.Exams", "Examinee_ExamineeId", "dbo.Examinees");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropForeignKey("dbo.Questions", "ExamSectionId", "dbo.ExamSections");
            DropForeignKey("dbo.ExamSections", "ExamId", "dbo.Exams");
            DropIndex("dbo.QuestionChoices", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "ExamSectionId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropIndex("dbo.ExamSections", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "Examinee_ExamineeId" });
            DropIndex("dbo.Entries", new[] { "ExamineeId" });
            DropIndex("dbo.Answers", new[] { "EntryId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropTable("dbo.QuestionChoices");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.ExamSections");
            DropTable("dbo.Exams");
            DropTable("dbo.Examinees");
            DropTable("dbo.Entries");
            DropTable("dbo.Answers");
        }
    }
}

namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptionSupport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionChoices", new[] { "QuestionId" });
            CreateTable(
                "dbo.OptionChoices",
                c => new
                    {
                        OptionChoiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OptionGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OptionChoiceId)
                .ForeignKey("dbo.OptionGroups", t => t.OptionGroupId, cascadeDelete: true)
                .Index(t => t.OptionGroupId);
            
            CreateTable(
                "dbo.OptionGroups",
                c => new
                    {
                        OptionGroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.OptionGroupId);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        QuestionOptionId = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        OptionChoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionOptionId)
                .ForeignKey("dbo.OptionChoices", t => t.OptionChoiceId, cascadeDelete: true)
                .Index(t => t.OptionChoiceId);
            
            DropTable("dbo.QuestionChoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        QuestionChoiceId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        ChoiceValue = c.String(),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionChoiceId);
            
            DropForeignKey("dbo.QuestionOptions", "OptionChoiceId", "dbo.OptionChoices");
            DropForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups");
            DropIndex("dbo.QuestionOptions", new[] { "OptionChoiceId" });
            DropIndex("dbo.OptionChoices", new[] { "OptionGroupId" });
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.OptionGroups");
            DropTable("dbo.OptionChoices");
            CreateIndex("dbo.QuestionChoices", "QuestionId");
            AddForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}

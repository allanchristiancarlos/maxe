namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionIdToOptionGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OptionGroups", "QuestionId", c => c.Int(nullable: false));
            CreateIndex("dbo.OptionGroups", "QuestionId");
            CreateIndex("dbo.QuestionOptions", "QuestionId");
            AddForeignKey("dbo.OptionGroups", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: false);
            AddForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.OptionGroups", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.OptionGroups", new[] { "QuestionId" });
            DropColumn("dbo.OptionGroups", "QuestionId");
        }
    }
}

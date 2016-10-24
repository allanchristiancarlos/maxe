namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswerItemTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups");
            DropIndex("dbo.OptionChoices", new[] { "OptionGroupId" });
            CreateTable(
                "dbo.AnswerItems",
                c => new
                    {
                        AnswerItemId = c.Int(nullable: false, identity: true),
                        ItemNumberValue = c.String(),
                        ItemStringValue = c.String(),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerItemId)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.AnswerId);
            
            AddColumn("dbo.Answers", "AnswerNumberValue", c => c.Int());
            AddColumn("dbo.Answers", "AnswerStringValue", c => c.String());
            AlterColumn("dbo.OptionChoices", "OptionGroupId", c => c.Int());
            CreateIndex("dbo.OptionChoices", "OptionGroupId");
            AddForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups", "OptionGroupId");
            DropColumn("dbo.Answers", "AnswerValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "AnswerValue", c => c.String());
            DropForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups");
            DropForeignKey("dbo.AnswerItems", "AnswerId", "dbo.Answers");
            DropIndex("dbo.OptionChoices", new[] { "OptionGroupId" });
            DropIndex("dbo.AnswerItems", new[] { "AnswerId" });
            AlterColumn("dbo.OptionChoices", "OptionGroupId", c => c.Int(nullable: false));
            DropColumn("dbo.Answers", "AnswerStringValue");
            DropColumn("dbo.Answers", "AnswerNumberValue");
            DropTable("dbo.AnswerItems");
            CreateIndex("dbo.OptionChoices", "OptionGroupId");
            AddForeignKey("dbo.OptionChoices", "OptionGroupId", "dbo.OptionGroups", "OptionGroupId", cascadeDelete: true);
        }
    }
}

namespace Maxe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeOptionGroupIdInOptionChoicesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OptionChoices", "OptionGroupId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
           
        }
    }
}

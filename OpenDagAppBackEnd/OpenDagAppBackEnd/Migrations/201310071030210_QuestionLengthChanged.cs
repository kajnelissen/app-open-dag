namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionLengthChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAnswerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "studyId", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "Rating");
            DropColumn("dbo.Answers", "studyId");
        }
    }
}

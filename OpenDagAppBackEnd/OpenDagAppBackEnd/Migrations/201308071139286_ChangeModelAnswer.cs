namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelAnswer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "StudyId", "dbo.Studies");
            DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "StudyId" });
            DropIndex("dbo.Answers", new[] { "Question_Id" });
            AddColumn("dbo.Answers", "Text", c => c.String(nullable: false, maxLength: 80));
            AddColumn("dbo.Answers", "QuestionId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
            CreateIndex("dbo.Answers", "QuestionId");
            DropColumn("dbo.Answers", "Title");
            DropColumn("dbo.Answers", "Content");
            DropColumn("dbo.Answers", "StudyId");
            DropColumn("dbo.Answers", "Question_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Question_Id", c => c.Int());
            AddColumn("dbo.Answers", "StudyId", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "Content", c => c.String(nullable: false));
            AddColumn("dbo.Answers", "Title", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropColumn("dbo.Answers", "QuestionId");
            DropColumn("dbo.Answers", "Text");
            CreateIndex("dbo.Answers", "Question_Id");
            CreateIndex("dbo.Answers", "StudyId");
            AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            AddForeignKey("dbo.Answers", "StudyId", "dbo.Studies", "Id", cascadeDelete: true);
        }
    }
}

namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAnswers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AnswerStudies", "AnswerId", "dbo.Answers");
            DropForeignKey("dbo.AnswerStudies", "StudyId", "dbo.Studies");
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.AnswerStudies", new[] { "AnswerId" });
            DropIndex("dbo.AnswerStudies", new[] { "StudyId" });
            DropTable("dbo.Answers");
            DropTable("dbo.AnswerStudies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AnswerStudies",
                c => new
                    {
                        AnswerId = c.Int(nullable: false),
                        StudyId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnswerId, t.StudyId });
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 80),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AnswerStudies", "StudyId");
            CreateIndex("dbo.AnswerStudies", "AnswerId");
            CreateIndex("dbo.Answers", "QuestionId");
            AddForeignKey("dbo.AnswerStudies", "StudyId", "dbo.Studies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AnswerStudies", "AnswerId", "dbo.Answers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Answers", "QuestionId", "dbo.Questions", "Id", cascadeDelete: true);
        }
    }
}

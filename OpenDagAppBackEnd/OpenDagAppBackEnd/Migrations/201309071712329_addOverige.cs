namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOverige : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerStudies",
                c => new
                    {
                        AnswerId = c.Int(nullable: false),
                        StudyId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnswerId, t.StudyId })
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Studies", t => t.StudyId, cascadeDelete: true)
                .Index(t => t.AnswerId)
                .Index(t => t.StudyId);
            
            DropColumn("dbo.Answers", "studyId");
            DropColumn("dbo.Answers", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "studyId", c => c.Int(nullable: false));
            DropIndex("dbo.AnswerStudies", new[] { "StudyId" });
            DropIndex("dbo.AnswerStudies", new[] { "AnswerId" });
            DropForeignKey("dbo.AnswerStudies", "StudyId", "dbo.Studies");
            DropForeignKey("dbo.AnswerStudies", "AnswerId", "dbo.Answers");
            DropTable("dbo.AnswerStudies");
        }
    }
}

namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NavigationRoutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NavigationTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NavigationRoutes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 50),
                        SurveyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                        StudyId = c.Int(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Studies", t => t.StudyId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.StudyId)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Studies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ShortName = c.String(nullable: false, maxLength: 5),
                        StudyInformationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false),
                        StudyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Studies", t => t.StudyId, cascadeDelete: true)
                .Index(t => t.StudyId);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeTableEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 120),
                        Location = c.String(nullable: false, maxLength: 30),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TimeTableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TimeTables", t => t.TimeTableId, cascadeDelete: true)
                .Index(t => t.TimeTableId);
            
        }
        
        public override void Down()
        {
            //DropIndex("dbo.TimeTableEntries", new[] { "TimeTableId" });
            //DropIndex("dbo.StudyInformations", new[] { "StudyId" });
            //DropIndex("dbo.Answers", new[] { "Question_Id" });
            //DropIndex("dbo.Answers", new[] { "StudyId" });
            //DropIndex("dbo.Questions", new[] { "SurveyId" });
            //DropIndex("dbo.NavigationTracks", new[] { "RouteId" });
            //DropForeignKey("dbo.TimeTableEntries", "TimeTableId", "dbo.TimeTables");
            //DropForeignKey("dbo.StudyInformations", "StudyId", "dbo.Studies");
            //DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            //DropForeignKey("dbo.Answers", "StudyId", "dbo.Studies");
            //DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            //DropForeignKey("dbo.NavigationTracks", "RouteId", "dbo.NavigationRoutes");
            //DropTable("dbo.TimeTableEntries");
            //DropTable("dbo.TimeTables");
            //DropTable("dbo.StudyInformations");
            //DropTable("dbo.Studies");
            //DropTable("dbo.Answers");
            //DropTable("dbo.Questions");
            //DropTable("dbo.Surveys");
            //DropTable("dbo.NavigationTracks");
            //DropTable("dbo.NavigationRoutes");
        }
    }
}

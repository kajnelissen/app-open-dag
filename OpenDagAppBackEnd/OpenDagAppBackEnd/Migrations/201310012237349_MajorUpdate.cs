namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MajorUpdate : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Answers", "StudyId", "dbo.Studies");
            //DropForeignKey("dbo.Answers", "Question_Id", "dbo.Questions");
            //DropIndex("dbo.Answers", new[] { "StudyId" });
            //DropIndex("dbo.Answers", new[] { "Question_Id" });
            //AddColumn("dbo.NavigationRoutes", "Active", c => c.Boolean(nullable: false));
            //AddColumn("dbo.NavigationTracks", "FileName", c => c.String());
            //AddColumn("dbo.TimeTables", "Active", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.NavigationTracks", "Image", c => c.String());
            //DropTable("dbo.Answers");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Answers",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Title = c.String(nullable: false, maxLength: 50),
            //            Content = c.String(nullable: false),
            //            StudyId = c.Int(nullable: false),
            //            Question_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AlterColumn("dbo.NavigationTracks", "Image", c => c.Binary());
            //DropColumn("dbo.TimeTables", "Active");
            //DropColumn("dbo.NavigationTracks", "FileName");
            //DropColumn("dbo.NavigationRoutes", "Active");
            //CreateIndex("dbo.Answers", "Question_Id");
            //CreateIndex("dbo.Answers", "StudyId");
            //AddForeignKey("dbo.Answers", "Question_Id", "dbo.Questions", "Id");
            //AddForeignKey("dbo.Answers", "StudyId", "dbo.Studies", "Id", cascadeDelete: true);
        }
    }
}

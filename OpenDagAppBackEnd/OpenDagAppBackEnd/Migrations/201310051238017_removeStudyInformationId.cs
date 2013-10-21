namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeStudyInformationId : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studies", "StudyInformationId");
        }
    }
}

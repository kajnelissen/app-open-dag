namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFromStudy : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Studies", "StudyInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Studies", "StudyInformationId", c => c.Int(nullable: false));
        }
    }
}

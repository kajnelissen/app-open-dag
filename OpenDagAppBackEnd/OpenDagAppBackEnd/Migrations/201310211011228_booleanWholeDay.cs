namespace OpenDagAppBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booleanWholeDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTableEntries", "WholeDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeTableEntries", "WholeDay");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OpenDagAppBackEnd.Models
{
    public class OpenDagAppBackEndContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<OpenDagAppBackEnd.Models.OpenDagAppBackEndContext>());


        //public OpenDagAppBackEndContext()
        //    : base("name=OpenDagAppBackEndContext")

        public OpenDagAppBackEndContext()
            : base("DB_9AA598_opendagzuyd2013")
        {
        }

        public DbSet<OpenDagAppBackEnd.Models.NavigationRoute> NavigationRoute { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Survey> Survey { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.TimeTable> TimeTable { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Question> Question { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.NavigationTrack> NavigationTrack { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.StudyInformation> StudyInformation { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.TimeTableEntry> TimeTableEntry { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Study> Study { get; set; }
    }
}
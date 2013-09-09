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

        //public OpenDagAppBackEndContext() : base("name=OpenDagAppBackEndContext")
        public OpenDagAppBackEndContext() : base("name=DB_9AA598_opendagzuydfacict")
        {
        }

        public DbSet<OpenDagAppBackEnd.Models.NavigationRoute> NavigationRoute { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Survey> Survey { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.TimeTable> TimeTable { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Question> Question { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Answer> Answer { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.NavigationTrack> NavigationTrack { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.StudyInformation> StudyInformation { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.TimeTableEntry> TimeTableEntry { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.Study> Study { get; set; }

        public DbSet<OpenDagAppBackEnd.Models.AnswerStudy> AnswerStudy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerStudy>()
                .HasRequired(x => x.Answer);

            modelBuilder.Entity<AnswerStudy>()
                .HasRequired(x => x.Study);

            // comment
            /*modelBuilder.Entity<Answer>()
                        .HasMany<Study>(e => e.)
                        //.WithMany(u => u.AnswerStudies)
                        .Map(m =>
                        {
                            m.ToTable("AnswerStudies");
                            m.MapLeftKey("AnswerID");
                            m.MapRightKey("StudyID");
                        });*/
            /*modelBuilder.Entity<Answer>()
                .HasMany(t => t.AnswerStudies)
                .WithMany(t => t.)
                .Map(m =>
                {
                    m.ToTable("AnswerStudies");
                    m.MapLeftKey("AnswerID");
                    m.MapRightKey("StudyID");
                });*/

            /*modelBuilder.Entity<AnswerStudy>()
               .HasKey(cp => new { cp.AnswerId, cp.StudyId });*/

            /*
             * HIERONDER COMMENTAAR WEGHALEN
             */

            /*modelBuilder.Entity<Answer>()
                        .HasMany(a => a.AnswerStudies)
                        .WithRequired()
                        .HasForeignKey(cp => cp.AnswerId);

            modelBuilder.Entity<Study>()
                        .HasMany(p => p.AnswerStudies)
                        .WithRequired()
                        .HasForeignKey(cp => cp.StudyId);  */
            
            /*modelBuilder.Entity<AnswerStudy>()
                        .HasRequired(a => a.Answer)
                        .WithMany(b => b.AnswerStudies);
            modelBuilder.Entity<AnswerStudy>()
                        .HasRequired(a => a.Study)
                        .WithMany(b => b.AnswerStudies);*/    // b => b.ArmorialAwards
        }
    }
}
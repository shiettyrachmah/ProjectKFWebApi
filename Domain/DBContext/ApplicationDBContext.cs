using Microsoft.EntityFrameworkCore;
using WebAPI.DTO.Domain;

namespace ProjectKFWebApi.Domain.DBContext
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Molecules> Molecules { get; set; }

        public virtual DbSet<Study> Study { get; set; }

        public virtual DbSet<StudyStatus> StudyStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Molecules>().ToTable("Molecules");

            //seed data to table Molecules from datajson
            string dataJson = System.IO.File.ReadAllText("DataSeedMolecule.json");

            List<Molecules> mol = System.Text.Json.JsonSerializer.Deserialize<List<Molecules>>(dataJson);

            foreach (Molecules items in mol)
            {
                modelBuilder.Entity<Molecules>().HasData(items);
            }

            //seed data to table StudyStatus from datajson
            string dataJson2 = System.IO.File.ReadAllText("DataSeedStudyStatus.json");

            List<StudyStatus> studystatus = System.Text.Json.JsonSerializer.Deserialize<List<StudyStatus>>(dataJson2);

            foreach (StudyStatus items in studystatus)
            {
                modelBuilder.Entity<StudyStatus>().HasData(items);
            }

        }
    }
}

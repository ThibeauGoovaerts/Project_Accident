using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class AccidentContext : IdentityDbContext {
        public AccidentContext(DbContextOptions<AccidentContext> options) : base(options)
        {        }

        public DbSet<DirectMesure> DirectMesures { get; set; }
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<ProposedMesure> ProposedMesures { get; set; }
        public DbSet<ProposedMesureDetail> ProposedMesureDetails { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FundamentaryCause> FundamentaryCauses { get; set; }
        public DbSet<MaterialAgent> MaterialAgents { get; set; }
        public DbSet<MaterialAgentDetail> MaterialAgentDetails { get; set; }
        public DbSet<Deviation> Deviations { get; set; }
        public DbSet<DeviationDetail> DeviationDetails { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<NatureLesion> NatureLesions { get; set; }
        public DbSet<NatureLesionDetail> NatureLesionDetails { get; set; }
        public DbSet<LesionSeat> LesionSeats { get; set; }
        public DbSet<LesionSeatDetail> LesionSeatDetails { get; set; }
        public DbSet<Protection> Protections { get; set; }
        public DbSet<VictimProtectionAsset> VictimProtectionAssets { get; set; }
        public DbSet<VictimInformation> VictimInformations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OutsideFirm> OutsideFirms { get; set; }


        //Pourque le id des tables soit une clé composée avec deux attributs, on le spécifie dans cette fonction
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<VictimProtectionAsset>().HasKey(table => new {
                table.VictimInformationID,
                table.ProtectionID
            });

            //Mise en avance de la relation 1v1 de accident et victimInformation, on dit que l'info sur la victime dépande de l'accident
            builder.Entity<Accident>()
            .HasOne(a => a.VictimInformation)
            .WithOne(a => a.Accident)
            .HasForeignKey<VictimInformation>(c => c.AccidentID);
        }
    }
}

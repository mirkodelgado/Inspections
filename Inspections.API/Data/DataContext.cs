using Microsoft.EntityFrameworkCore;

using Inspections.API.Models;

namespace Inspections.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }


        public  DbSet<InspectionM> InspectionsM { get; set; }
        public  DbSet<BillToClient> BillToClient { get; set; }
        public  DbSet<Location> Depot { get; set; }
        public  DbSet<InspectionD> InspectionsD { get; set; }
        public  DbSet<TaskSchedule> TaskSchedule { get; set; }
        public  DbSet<Locations> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionM>()
                .HasKey(k => new { k.ImClientId, k.ImVendorId, k.ImDepotId, k.ImInspectionRefNmbr });

            modelBuilder.Entity<Location>()
                .HasKey(dpt => new { dpt.DptClientId, dpt.DptVendorId, dpt.DptDepotId, dpt.DptBillToClientId });

           modelBuilder.Entity<InspectionD>()
                .HasKey(k => new { k.IdClientId, k.IdVendorId, k.IdDepotId, k.IdInspectionRefNmbr, k.IdLineNmbr });

           modelBuilder.Entity<Locations>()
                .HasKey(lg => new { lg.LgClientId, lg.LgBillToCid, lg.LgGroupId, lg.LgRepairCategory, lg.LgLocationNmbr });

            //modelBuilder.Entity<InspectionD>()
            //            .HasOne(d => d.InspectionM)
            //            .WithMany(m => m.InspectionD);                
        }


    }
}
using APBD_Midterm2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Midterm2.Data;

public class DatabaseContext : DbContext
{
    //I stole the nameing logic from your examples hope you do not mind
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<WashingMachine> Machines => Set<WashingMachine>();
    public DbSet<Models.Program> Programs => Set<Models.Program>();
    public DbSet<Purchase> Purchases => Set<Purchase>();
    public DbSet<PurchaseProgram> PurchasePrograms => Set<PurchaseProgram>();
    public DbSet<MachineProgram> MachinePrograms => Set<MachineProgram>();

    public DatabaseContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PurchaseProgram>().HasKey(pp => new { pp.PurchaseId, pp.ProgramId });
        modelBuilder.Entity<MachineProgram>().HasKey(mp => new { WashingMachineId = mp.MachineId, mp.ProgramDefId });

        modelBuilder.Entity<Models.Program>().HasData(
            new Models.Program { Id = 1, Name = "Quick Wash", Duration = 69 },
            new Models.Program { Id = 2, Name = "Cotton Cycle", Duration = 143 },
            new Models.Program { Id = 3, Name = "Synthetic", Duration = 100 }
        );
    }
}
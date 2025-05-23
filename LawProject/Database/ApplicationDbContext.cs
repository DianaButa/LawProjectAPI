using LawProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace LawProject.Database
{
  public class ApplicationDbContext : DbContext
  {

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ClientPF> ClientPFs { get; set; }

    public DbSet<ClientPJ> ClientPJs { get; set; }

    public DbSet<MyFile> Files { get; set; }

    public DbSet<Notes> Notes { get; set; }

    public DbSet<Lawyer> Lawyers { get; set; }

    public DbSet<Notification> Notifications { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<ScheduledEvent> ScheduledEvents { get; set; }

    public DbSet<ClientPFFile> ClientPFFiles { get; set; }
    public DbSet<ClientPJFile> ClientPJFiles { get; set; }
    public DbSet<LawyerFile> LawyerFiles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Configurarea relației many-to-many între ClientPF și MyFile
      modelBuilder.Entity<ClientPFFile>()
          .HasKey(cp => new { cp.ClientPFId, cp.MyFileId });

      modelBuilder.Entity<ClientPFFile>()
          .HasOne(cp => cp.ClientPF)
          .WithMany(c => c.ClientPFFiles)
          .HasForeignKey(cp => cp.ClientPFId);

      modelBuilder.Entity<ClientPFFile>()
          .HasOne(cp => cp.MyFile)
          .WithMany(m => m.ClientPFFiles)
          .HasForeignKey(cp => cp.MyFileId);

      // Configurarea relației many-to-many între ClientPJ și MyFile
      modelBuilder.Entity<ClientPJFile>()
          .HasKey(cj => new { cj.ClientPJId, cj.MyFileId });

      modelBuilder.Entity<ClientPJFile>()
          .HasOne(cj => cj.ClientPJ)
          .WithMany(c => c.ClientPJFiles)
          .HasForeignKey(cj => cj.ClientPJId);

      modelBuilder.Entity<ClientPJFile>()
          .HasOne(cj => cj.MyFile)
          .WithMany(m => m.ClientPJFiles)
          .HasForeignKey(cj => cj.MyFileId);
    

    modelBuilder.Entity<LawyerFile>()
             .HasKey(lf => new { lf.LawyerId, lf.FileId });

      modelBuilder.Entity<LawyerFile>()
          .HasOne(lf => lf.Lawyer)
          .WithMany(l => l.LawyerFiles)
          .HasForeignKey(lf => lf.LawyerId)
          .OnDelete(DeleteBehavior.NoAction); // Adăugat NO ACTION pentru a evita conflictele de cascade delete

      modelBuilder.Entity<LawyerFile>()
          .HasOne(lf => lf.File)
          .WithMany(f => f.LawyerFiles)
          .HasForeignKey(lf => lf.FileId)
          .OnDelete(DeleteBehavior.NoAction);

    }
  }
}



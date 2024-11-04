
using DonMacaron.Entities;
using DonMacaron.Entities.Products.Macarons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DonMacaron.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Macaron> Macarons { get; set; }
    public DbSet<MacaronsVersion> MacaronsVersions {get; set;}
    public DbSet<Allergen> Allergens { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<MacaronsBox> MacaronsBoxes { get; set; }
    public DbSet<MacaronsBoxVersion> MacaronsBoxVersions{get; set;}
    public DbSet<SmallMacaronsSet> SmallMacaronsSets {get; set;}

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Login)
            .IsUnique();

        modelBuilder.Entity<Macaron>()
            .HasOne(m => m.CurrentVersion)         // Встановлюємо зв'язок
            .WithMany()                            // Односторонній зв'язок
            .HasForeignKey(m => m.CurrentVersionId) // Вказуємо зовнішній ключ
            .IsRequired();                         // Задаємо, що поле обов'язкове

        modelBuilder.Entity<Macaron>()
            .HasMany(m => m.MacaronsVersions)       
            .WithOne(); 

        modelBuilder.Entity<MacaronsBox>()
            .HasOne(m => m.CurrentVersion)         // Встановлюємо зв'язок
            .WithMany()                            // Односторонній зв'язок
            .HasForeignKey(m => m.CurrentVersionId) // Вказуємо зовнішній ключ
            .IsRequired();                         // Задаємо, що поле обов'язкове

        modelBuilder.Entity<MacaronsBox>()
            .HasMany(m => m.MacaronsBoxVersions)       
            .WithOne(); 
    }
}

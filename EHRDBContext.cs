using Microsoft.EntityFrameworkCore;
using HL7_EHR_SQLite_Demo.DataModel;

namespace HL7_EHR_SQLite_Demo
{
    public class EHRDBContext(DbContextOptions<EHRDBContext> options) : DbContext(options)
    {
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Act> Acts { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ActRelationship> ActRelationships { get; set; }
        public DbSet<RoleLink> RoleLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Make explicit primary keys
            modelBuilder.Entity<Entity>().HasKey(e => e.Id);
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<RoleLink>().HasKey(rl => rl.Id);
            modelBuilder.Entity<Participation>().HasKey(p => p.Id);
            modelBuilder.Entity<Act>().HasKey(a => a.Id);
            modelBuilder.Entity<ActRelationship>().HasKey(ar => ar.Id);

            //Inheritance
            modelBuilder.Entity<Person>().HasBaseType<Entity>();
            modelBuilder.Entity<Material>().HasBaseType<Entity>();
            modelBuilder.Entity<Organization>().HasBaseType<Entity>();


            //Foreign Key Constraints
            modelBuilder.Entity<RoleLink>()
                .HasOne(rl => rl.Source)
                .WithMany(r => r.SourceRoleLinks)
                .HasForeignKey(rl => rl.SourceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RoleLink>()
                .HasOne(rl => rl.Target)
                .WithMany(r => r.TargetRoleLinks)
                .HasForeignKey(rl => rl.TargetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActRelationship>()
                .HasOne(ar => ar.Source)
                .WithMany(a => a.SourceRelationships)
                .HasForeignKey(ar => ar.SourceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ActRelationship>()
                .HasOne(ar => ar.Target)
                .WithMany(a => a.TargetRelationships)
                .HasForeignKey(ar => ar.TargetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Role)
                .WithMany(r => r.Participations)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Participation>()
                .HasOne(p => p.Act)
                .WithMany(a => a.Participations)
                .HasForeignKey(p => p.ActId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.PlayingRoles)
                .WithOne(r => r.PlayingEntity)
                .HasForeignKey(r => r.PlayingEntityID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Entity>()
                .HasMany(e => e.ScopingRoles)
                .WithOne(r => r.ScopingEntity)
                .HasForeignKey(r => r.ScopingEntityID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

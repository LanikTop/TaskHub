using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context
{
    public sealed class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
        {
        }

        public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.ToTable("tasks");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedByUserId)
                    .HasColumnName("created_by_user_id")
                    .IsRequired();

                entity.Property(e => e.CreatedUtc)
                    .HasColumnName("created_utc")
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(e => e.CreatedByUserId)
                    .HasPrincipalKey(u => u.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.ToTable("tasks");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

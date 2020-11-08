using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class BackEndContext : DbContext
    {
        public BackEndContext()
        {

        }
        public BackEndContext(DbContextOptions<BackEndContext> opt) : base(opt)
        {
            
        }

         public static BackEndContext CreateContext()
        {
            var dbContext = new BackEndContext();
            return dbContext;
        }


        
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddGlobalFilters(modelBuilder);
            modelBuilder.Entity<Business>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.Property(entity => entity.DateDeleted).HasColumnType("datetime");
                entity.Property(entity => entity.DateEntered).HasColumnType("datetime");
                entity.Property(entity => entity.DateModified).HasColumnType("datetime");
            });

        }

         public static bool GlobalFiltersAdded { get; set; } = false;

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!BackEndContext.GlobalFiltersAdded)
            {
                throw new Exception("AddGlobalFilters(modelBuilder); must be added to the OnModelCreating method on the base data context.");
            }

            ChangeTracker.DetectChanges();

            SaveUpdates("Admin");

            return SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public Task<int> SaveChangesAsyncWithUser(string UserEntered, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!BackEndContext.GlobalFiltersAdded)
            {
                throw new Exception("AddGlobalFilters(modelBuilder); must be added to the OnModelCreating method on the base data context.");
            }

            ChangeTracker.DetectChanges();

            SaveUpdates(UserEntered);

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            SaveUpdates(null);

            var result = base.SaveChanges();
            return result;
        }

        public int SaveChanges(string UserEntered)
        {
            ChangeTracker.DetectChanges();

            SaveUpdates(UserEntered);

            var result = base.SaveChanges();
            return result;
        }

        private void SaveUpdates(string UserEntered)
        {


                foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
                {
                    var t = entry.Entity.GetType();
                    if (t.GetProperty("DateEntered") != null)
                    {
                        t.GetProperty("DateEntered").SetValue(entry.Entity, DateTime.Now);
                    }
                    if (t.GetProperty("UserEntered") != null)
                    {
                        t.GetProperty("UserEntered").SetValue(entry.Entity, "Admin");
                    }
                }

            //foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            //{
            //    var t = entry.Entity.GetType();
            //    if (t.GetProperty("DateModified") != null)
            //    {
            //        DateTime now = DateTime.Now.ToLocalTime();
            //        t.GetProperty("DateModified").SetValue(entry.Entity, now);
            //    }
            //    if (t.GetProperty("UserModified") != null)
            //    {
            //        t.GetProperty("UserModified").SetValue(entry.Entity, "Admin");
            //    }
            //}
        }

        private void AddGlobalFilters(ModelBuilder modelBuilder)
        {
            BackEndContext.GlobalFiltersAdded = true;
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var dateDeletedProperty = entityType.FindProperty("DateDeleted");
                if (dateDeletedProperty != null && dateDeletedProperty.ClrType == typeof(DateTime?))
                {
                    var parameterExpression = Expression.Parameter(entityType.ClrType, "x");
                    var deletedProperty = Expression.Property(parameterExpression, "DateDeleted");
                    var nullConstant = Expression.Constant(null);
                    var expression = Expression.Equal(deletedProperty, nullConstant);
                    var filter = Expression.Lambda(expression, parameterExpression);
                    entityType.SetQueryFilter(filter);
                }
            }
        }
    }
}
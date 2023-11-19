using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ToDoList.Data
{
    public class ToDoContext : DbContext
    {
        // Magic string.
        public static readonly string RowVersion = nameof(RowVersion);

        // Magic strings.
        public static readonly string ToDoDb = nameof(ToDoDb).ToLower();

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            Debug.WriteLine($"{ContextId} context created.");
        }

        public DbSet<Entities.ToDo> ToDos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entities.ToDo>().ToTable(nameof(Entities.ToDo));
            modelBuilder.Entity<Entities.ToDo>().Property<byte[]>(RowVersion).IsRowVersion();

            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            Debug.WriteLine($"{ContextId} context disposed.");
            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            Debug.WriteLine($"{ContextId} context disposed async.");
            return base.DisposeAsync();
        }

    }
}

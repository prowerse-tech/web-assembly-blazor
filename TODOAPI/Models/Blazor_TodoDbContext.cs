using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoLibrary;

namespace TODOAPI.Models
{
    public partial class Blazor_TodoDbContext : DbContext
    {
        public Blazor_TodoDbContext()
        {
        }

        public Blazor_TodoDbContext(DbContextOptions<Blazor_TodoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ToDo> ToDo { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.;Database=Blazor_TodoDb;Trusted_Connection=True;");
//            }
//        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ToDo>(entity =>
        //    {
        //        entity.HasNoKey();

        //        //entity.Property(e => e.DueDate).HasColumnType("datetime");

        //        entity.Property(e => e.Id).ValueGeneratedOnAdd();

        //        entity.Property(e => e.Status).IsRequired();

        //        entity.Property(e => e.Task)
        //            .IsRequired()
        //            .HasMaxLength(100);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

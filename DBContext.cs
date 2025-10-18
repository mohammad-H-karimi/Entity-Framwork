using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Entity_Framework
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipCard> MembershipCards { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AJ8D32P\\SQLEXPRESS;Database=Entity-Framework;Trusted_Connection=True;TrustServerCertificate=True;");
       
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(j => j.ToTable("BookAuthors"));

        
            modelBuilder.Entity<Member>()
                .HasOne(m => m.MembershipCard)
                .WithOne(c => c.Member)
                .HasForeignKey<MembershipCard>(c => c.MemberId);

            
            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.Member)
                .WithMany(m => m.BookLoans)
                .HasForeignKey(bl => bl.MemberId);

        
            modelBuilder.Entity<BookLoan>()
                .HasOne(bl => bl.Book)
                .WithMany()
                .HasForeignKey(bl => bl.BookId);
        }
    }
}


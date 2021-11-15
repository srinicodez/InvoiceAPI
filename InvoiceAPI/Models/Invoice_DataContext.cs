
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace InvoiceAPI.Models
{
    public partial class Invoice_DataContext : DbContext
    {
      
        public IConfiguration Configuration { get; }

        public Invoice_DataContext(DbContextOptions<Invoice_DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblInvoiceDatum> TblInvoiceData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KFGNBGQ;Initial Catalog=Invoice_Data;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblInvoiceDatum>(entity =>
            {
                entity.HasKey(e => e.SeqId);

                entity.ToTable("tbl_Invoice_Data");

                entity.Property(e => e.SeqId).HasColumnName("SeqID");

                entity.Property(e => e.AudEquivalent)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Aud_Equivalent");

                entity.Property(e => e.BillToAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyEmail)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyPhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DueDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.InvoiceDate)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.SalesTax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("subTotal");

                entity.Property(e => e.TotalDue)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace DataService.DBModels;

public partial class BricsrecosystemContext : DbContext
{
    public BricsrecosystemContext()
    {
    }

    public BricsrecosystemContext(DbContextOptions<BricsrecosystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Icicialertnotification> Icicialertnotifications { get; set; }

    public virtual DbSet<Icicilog> Icicilogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=manish1996;database=bricsrecosystem", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Icicialertnotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("icicialertnotification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .HasColumnName("accountNumber");
            entity.Property(e => e.AlertSequenceNumber)
                .HasMaxLength(50)
                .HasColumnName("alertSequenceNumber");
            entity.Property(e => e.Amount)
                .HasPrecision(16, 2)
                .HasColumnName("amount");
            entity.Property(e => e.ChequeNumber)
                .HasMaxLength(20)
                .HasColumnName("chequeNumber");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("createdOn");
            entity.Property(e => e.DebitCredit)
                .HasMaxLength(50)
                .HasColumnName("debitCredit");
            entity.Property(e => e.MnemonicCode)
                .HasMaxLength(50)
                .HasColumnName("mnemonicCode");
            entity.Property(e => e.RemitterAccount)
                .HasMaxLength(100)
                .HasColumnName("remitterAccount");
            entity.Property(e => e.RemitterBank)
                .HasMaxLength(100)
                .HasColumnName("remitterBank");
            entity.Property(e => e.RemitterIfscCode)
                .HasMaxLength(100)
                .HasColumnName("remitterIfscCode");
            entity.Property(e => e.RemitterName)
                .HasMaxLength(100)
                .HasColumnName("remitterName");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("timestamp")
                .HasColumnName("transactionDate");
            entity.Property(e => e.UserReferenceNumber)
                .HasMaxLength(100)
                .HasColumnName("userReferenceNumber");
            entity.Property(e => e.ValueDate).HasColumnName("valueDate");
            entity.Property(e => e.VirtualAccount)
                .HasMaxLength(100)
                .HasColumnName("virtualAccount");
        });

        modelBuilder.Entity<Icicilog>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("icicilog");

            entity.Property(e => e.RequestId)
                .HasMaxLength(200)
                .HasColumnName("requestId");
            entity.Property(e => e.Encryptedrequest)
                .HasColumnType("text")
                .HasColumnName("encryptedrequest");
            entity.Property(e => e.Encryptedresponse)
                .HasColumnType("text")
                .HasColumnName("encryptedresponse");
            entity.Property(e => e.Errorlog)
                .HasColumnType("text")
                .HasColumnName("errorlog");
            entity.Property(e => e.Iv)
                .HasColumnType("text")
                .HasColumnName("iv");
            entity.Property(e => e.Logdatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("logdatetime");
            entity.Property(e => e.Requestbody)
                .HasColumnType("text")
                .HasColumnName("requestbody");
            entity.Property(e => e.Response)
                .HasColumnType("text")
                .HasColumnName("response");
            entity.Property(e => e.Sourceapi)
                .HasMaxLength(50)
                .HasColumnName("sourceapi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

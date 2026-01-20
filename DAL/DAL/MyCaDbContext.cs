using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities.Models;

public partial class MyCaDbContext : DbContext
{
    public IConfiguration? _configuration;

    public MyCaDbContext()
    {
    }

    public MyCaDbContext(DbContextOptions<MyCaDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TlkpCountry> TlkpCountries { get; set; }

    public virtual DbSet<TlkpRole> TlkpRoles { get; set; }

    public virtual DbSet<TCertificate> TCertificates { get; set; }

    public virtual DbSet<TWork> TWorks { get; set; }

    public virtual DbSet<TCategory> TCategories { get; set; }

    public virtual DbSet<TFaq> TFaqs { get; set; }


  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__T_USER__3214EC2770A1141C");

            entity.ToTable("T_USER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("address2");
            entity.Property(e => e.BillingAddress1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("billing_address1");
            entity.Property(e => e.BillingAddress2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("billing_address2");
            entity.Property(e => e.BillingCity)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("billing_city");
            entity.Property(e => e.BillingPhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("billing_phone_number");
            entity.Property(e => e.BillingStateRegion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("billing_state_region");
            entity.Property(e => e.BillingZipcode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("billing_zipcode");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyOfficialId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("company_official_ID");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("creation_date");
            entity.Property(e => e.DateEndSubscription)
                .HasColumnType("datetime")
                .HasColumnName("date_end_subscription");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.HowHearAboutUs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("how_hear_about_us");
            entity.Property(e => e.IdBillingCountry).HasColumnName("ID_billing_country");
            entity.Property(e => e.IdCountry).HasColumnName("ID_country");
            entity.Property(e => e.IdRole).HasColumnName("ID_role");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("owner_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Profession)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("profession");
            entity.Property(e => e.RemainingTokens).HasColumnName("remaining_tokens");
            entity.Property(e => e.StateRegion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("state_region");
            entity.Property(e => e.Zipcode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("zipcode");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__T_USER__ID_billi__440B1D61");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.TUsers)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK__T_USER__ID_role__4222D4EF");
        });

        modelBuilder.Entity<TlkpCountry>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("PK__TLKP_COU__AC9B4F66474A81E6");

            entity.ToTable("TLKP_COUNTRY");

            entity.Property(e => e.IdCountry).HasColumnName("ID_country");
            entity.Property(e => e.CountryName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<TlkpRole>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__TLKP_ROL__45DFFBDBDDB40295");

            entity.ToTable("TLKP_ROLE");

            entity.Property(e => e.IdRole).HasColumnName("ID_role");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("role_description");
        });

        modelBuilder.Entity<TCertificate>(entity =>
        {
            entity.HasKey(e => e.IdCertificate).HasName("PK__T_CERTIF__21660F47D641E4F6");

            entity.ToTable("T_CERTIFICATE");

            entity.Property(e => e.IdCertificate).HasColumnName("ID_certificate");
            entity.Property(e => e.CertificateName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("certificate_name");
            entity.Property(e => e.IdFile)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ID_file");
            entity.Property(e => e.RegisrrationDate)
                .HasColumnType("datetime")
                .HasColumnName("regisrration_date");
            entity.Property(e => e.Tsa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TSA");
        });

        modelBuilder.Entity<TWork>(entity =>
        {
            entity.HasKey(e => e.IdWork).HasName("PK__T_WORK__825473673A20D9DD");

            entity.ToTable("T_WORK");

            entity.Property(e => e.IdWork).HasColumnName("ID_work");
            entity.Property(e => e.AdditionalCopyrightOwners)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("additional_copyright_owners");
            entity.Property(e => e.CopyrightOwner)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("copyright_owner");
            entity.Property(e => e.DisplayedId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("displayed_id");
            entity.Property(e => e.FileFingerprint)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("file_fingerprint");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("file_name");
            entity.Property(e => e.IdCertificate).HasColumnName("ID_certificate");
            entity.Property(e => e.IdClient).HasColumnName("ID_client");
            entity.Property(e => e.IdFile)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("ID_file");
            entity.Property(e => e.NumberForClient).HasColumnName("number_for_client");
            entity.Property(e => e.RegisrrationDate)
                .HasColumnType("datetime")
                .HasColumnName("regisrration_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("((1))")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__T_CATEGO__19093A2B255BE16D");

            entity.ToTable("T_CATEGORIES");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(255);
        });

        modelBuilder.Entity<TFaq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PK__T_FAQ__9C741C434BE50CE6");

            entity.ToTable("T_FAQ");

            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Question)
                .HasMaxLength(500)
                .HasColumnName("question");

            entity.HasOne(d => d.Category).WithMany(p => p.TFaqs)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__T_FAQ__CategoryI__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

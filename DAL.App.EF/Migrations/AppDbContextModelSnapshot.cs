﻿// <auto-generated />
using System;
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.App.BloodDonate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<Guid?>("BloodGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BloodTestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("BloodTestId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("DonorId");

                    b.ToTable("BloodDonate");
                });

            modelBuilder.Entity("Domain.App.BloodGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BloodGroupValue")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BloodGroup");
                });

            modelBuilder.Entity("Domain.App.BloodTest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Allowed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("BloodGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("DonorId");

                    b.ToTable("BloodTest");
                });

            modelBuilder.Entity("Domain.App.BloodTransfusion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("BloodGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DonorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("DonorId");

                    b.ToTable("BloodTransfusion");
                });

            modelBuilder.Entity("Domain.App.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContactTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactValueId")
                        .HasMaxLength(128)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("ContactValueId");

                    b.HasIndex("PersonId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Domain.App.ContactType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactTypeValueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypeValueId");

                    b.ToTable("ContactType");
                });

            modelBuilder.Entity("Domain.App.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Domain.App.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.App.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BloodGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("IdentificationCode")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid?>("PersonTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodGroupId");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Domain.App.PersonType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("PersonTypeValueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SecondaryPersonTypeValueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonTypeValueId");

                    b.HasIndex("SecondaryPersonTypeValueId");

                    b.ToTable("PersonType");
                });

            modelBuilder.Entity("Domain.App.TransferableBlood", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid?>("BloodDonateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BloodTransfusionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BloodDonateId");

                    b.HasIndex("BloodTransfusionId");

                    b.ToTable("TransferableBlood");
                });

            modelBuilder.Entity("Domain.Base.Identity.BaseAppUserRole<System.Guid, Domain.App.Identity.AppUser, Domain.App.Identity.AppRole>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Domain.Base.LangString", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("LangStrings");
                });

            modelBuilder.Entity("Domain.Base.Translation", b =>
                {
                    b.Property<string>("Culture")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<Guid>("LangStringId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(10240)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Culture", "LangStringId");

                    b.HasIndex("LangStringId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.App.BloodDonate", b =>
                {
                    b.HasOne("Domain.App.BloodGroup", "BloodGroup")
                        .WithMany("BloodTypes")
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.BloodTest", "BloodTest")
                        .WithMany("BloodDonates")
                        .HasForeignKey("BloodTestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.Person", "Doctor")
                        .WithMany("BloodDonateDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.Person", "Donor")
                        .WithMany("BloodDonateDonors")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BloodGroup");

                    b.Navigation("BloodTest");

                    b.Navigation("Doctor");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Domain.App.BloodTest", b =>
                {
                    b.HasOne("Domain.App.BloodGroup", "BloodGroup")
                        .WithMany("BloodTestBloodTypes")
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.Person", "Doctor")
                        .WithMany("BloodTestsDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.Person", "Donor")
                        .WithMany("BloodTestsDonors")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BloodGroup");

                    b.Navigation("Doctor");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Domain.App.BloodTransfusion", b =>
                {
                    b.HasOne("Domain.App.BloodGroup", "BloodGroup")
                        .WithMany("BloodTransfusionBloodTypes")
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.Person", "Doctor")
                        .WithMany("BloodTransfusionDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.Person", "Donor")
                        .WithMany("BloodTransfusionDonors")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BloodGroup");

                    b.Navigation("Doctor");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Domain.App.Contact", b =>
                {
                    b.HasOne("Domain.App.ContactType", "ContactType")
                        .WithMany("Contacts")
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Base.LangString", "ContactValue")
                        .WithMany()
                        .HasForeignKey("ContactValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.App.Person", "Person")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ContactType");

                    b.Navigation("ContactValue");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.App.ContactType", b =>
                {
                    b.HasOne("Domain.Base.LangString", "ContactTypeValue")
                        .WithMany()
                        .HasForeignKey("ContactTypeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ContactTypeValue");
                });

            modelBuilder.Entity("Domain.App.Person", b =>
                {
                    b.HasOne("Domain.App.BloodGroup", "BloodGroup")
                        .WithMany("PersonBloodTypes")
                        .HasForeignKey("BloodGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.PersonType", "PersonType")
                        .WithMany("People")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BloodGroup");

                    b.Navigation("PersonType");
                });

            modelBuilder.Entity("Domain.App.PersonType", b =>
                {
                    b.HasOne("Domain.Base.LangString", "PersonTypeValue")
                        .WithMany()
                        .HasForeignKey("PersonTypeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Base.LangString", "SecondaryPersonTypeValue")
                        .WithMany()
                        .HasForeignKey("SecondaryPersonTypeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PersonTypeValue");

                    b.Navigation("SecondaryPersonTypeValue");
                });

            modelBuilder.Entity("Domain.App.TransferableBlood", b =>
                {
                    b.HasOne("Domain.App.BloodDonate", "BloodDonate")
                        .WithMany("TransferableBlood")
                        .HasForeignKey("BloodDonateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.App.BloodTransfusion", "BloodTransfusion")
                        .WithMany("TransferableBlood")
                        .HasForeignKey("BloodTransfusionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BloodDonate");

                    b.Navigation("BloodTransfusion");
                });

            modelBuilder.Entity("Domain.Base.Identity.BaseAppUserRole<System.Guid, Domain.App.Identity.AppUser, Domain.App.Identity.AppRole>", b =>
                {
                    b.HasOne("Domain.App.Identity.AppRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.App.Identity.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Base.Translation", b =>
                {
                    b.HasOne("Domain.Base.LangString", "LangString")
                        .WithMany("Translations")
                        .HasForeignKey("LangStringId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LangString");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.App.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Domain.App.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Domain.App.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Domain.App.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.App.BloodDonate", b =>
                {
                    b.Navigation("TransferableBlood");
                });

            modelBuilder.Entity("Domain.App.BloodGroup", b =>
                {
                    b.Navigation("BloodTestBloodTypes");

                    b.Navigation("BloodTransfusionBloodTypes");

                    b.Navigation("BloodTypes");

                    b.Navigation("PersonBloodTypes");
                });

            modelBuilder.Entity("Domain.App.BloodTest", b =>
                {
                    b.Navigation("BloodDonates");
                });

            modelBuilder.Entity("Domain.App.BloodTransfusion", b =>
                {
                    b.Navigation("TransferableBlood");
                });

            modelBuilder.Entity("Domain.App.ContactType", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Domain.App.Person", b =>
                {
                    b.Navigation("BloodDonateDoctors");

                    b.Navigation("BloodDonateDonors");

                    b.Navigation("BloodTestsDoctors");

                    b.Navigation("BloodTestsDonors");

                    b.Navigation("BloodTransfusionDoctors");

                    b.Navigation("BloodTransfusionDonors");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Domain.App.PersonType", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Domain.Base.LangString", b =>
                {
                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}

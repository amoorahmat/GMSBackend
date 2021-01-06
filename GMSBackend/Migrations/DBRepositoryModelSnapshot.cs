﻿// <auto-generated />
using System;
using GMSBackend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GMSBackend.Migrations
{
    [DbContext(typeof(DBRepository))]
    partial class DBRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GMSBackend.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool?>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("Instagram")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("JobInfoId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("JoinDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("MembershipJoinTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<long?>("Referral")
                        .HasColumnType("bigint");

                    b.Property<string>("Tel")
                        .HasColumnType("text");

                    b.Property<string>("Telegram")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<long?>("VisitorID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("JobInfoId");

                    b.HasIndex("MembershipJoinTypeId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("GMSBackend.Entities.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("GMSBackend.Entities.JobInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("JobInfos");
                });

            modelBuilder.Entity("GMSBackend.Entities.MembershipJoinType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("MembershipJoinTypes");
                });

            modelBuilder.Entity("GMSBackend.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GMSBackend.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("GMSBackend.Entities.Account", b =>
                {
                    b.HasOne("GMSBackend.Entities.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMSBackend.Entities.JobInfo", "JobInfo")
                        .WithMany()
                        .HasForeignKey("JobInfoId");

                    b.HasOne("GMSBackend.Entities.MembershipJoinType", "MembershipJoinType")
                        .WithMany()
                        .HasForeignKey("MembershipJoinTypeId");

                    b.Navigation("AccountType");

                    b.Navigation("JobInfo");

                    b.Navigation("MembershipJoinType");
                });
#pragma warning restore 612, 618
        }
    }
}

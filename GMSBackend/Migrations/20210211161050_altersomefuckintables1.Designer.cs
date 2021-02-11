﻿// <auto-generated />
using System;
using GMSBackend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GMSBackend.Migrations
{
    [DbContext(typeof(DBRepository))]
    [Migration("20210211161050_altersomefuckintables1")]
    partial class altersomefuckintables1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GMSBackend.Entities.AccTransaction", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("AccountID")
                        .HasColumnType("bigint");

                    b.Property<int?>("AccountTypeID")
                        .HasColumnType("integer");

                    b.Property<long>("account_id")
                        .HasColumnType("bigint");

                    b.Property<int>("account_type_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("deleted_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<long?>("invoice_id")
                        .HasColumnType("bigint");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_variz")
                        .HasColumnType("boolean");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("AccountID");

                    b.HasIndex("AccountTypeID");

                    b.ToTable("acc_transactions");
                });

            modelBuilder.Entity("GMSBackend.Entities.Account", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool?>("Gender")
                        .HasColumnType("boolean");

                    b.Property<int>("account_type_id")
                        .HasColumnType("integer");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<decimal>("balance")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("birth_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("contract_file_path")
                        .HasColumnType("text");

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("full_name")
                        .HasColumnType("text");

                    b.Property<string>("instagram")
                        .HasColumnType("text");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("jobinfo_id")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("join_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("membership_join_type_id")
                        .HasColumnType("integer");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("postal_code")
                        .HasColumnType("text");

                    b.Property<long?>("referral")
                        .HasColumnType("bigint");

                    b.Property<string>("tel")
                        .HasColumnType("text");

                    b.Property<string>("telegram")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<long?>("visitor_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("GMSBackend.Entities.AccountType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("id");

                    b.ToTable("account_types");
                });

            modelBuilder.Entity("GMSBackend.Entities.ClientPeriodicCheckUp", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<double?>("abs")
                        .HasColumnType("double precision");

                    b.Property<long>("account_id")
                        .HasColumnType("bigint");

                    b.Property<double?>("butt")
                        .HasColumnType("double precision");

                    b.Property<double?>("chest")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<double?>("height")
                        .HasColumnType("double precision");

                    b.Property<string>("img_url")
                        .HasColumnType("text");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<double?>("left_arm")
                        .HasColumnType("double precision");

                    b.Property<double?>("left_calves")
                        .HasColumnType("double precision");

                    b.Property<double?>("left_thigh")
                        .HasColumnType("double precision");

                    b.Property<double?>("right_arm")
                        .HasColumnType("double precision");

                    b.Property<double?>("right_calves")
                        .HasColumnType("double precision");

                    b.Property<double?>("right_thigh")
                        .HasColumnType("double precision");

                    b.Property<int>("session_no")
                        .HasColumnType("integer");

                    b.Property<double?>("waist_size")
                        .HasColumnType("double precision");

                    b.Property<double?>("weight")
                        .HasColumnType("double precision");

                    b.HasKey("id");

                    b.ToTable("client_periodic_checkups");
                });

            modelBuilder.Entity("GMSBackend.Entities.JobInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("id");

                    b.ToTable("job_infos");
                });

            modelBuilder.Entity("GMSBackend.Entities.MembershipJoinType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("id");

                    b.ToTable("membership_join_types");
                });

            modelBuilder.Entity("GMSBackend.Entities.Product", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<double?>("buy_price")
                        .HasColumnType("double precision");

                    b.Property<long>("coding_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("end_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("product_barcode")
                        .HasColumnType("text");

                    b.Property<string>("product_code")
                        .HasColumnType("text");

                    b.Property<string>("product_name")
                        .HasColumnType("text");

                    b.Property<double?>("sale_price")
                        .HasColumnType("double precision");

                    b.Property<double?>("sale_price2")
                        .HasColumnType("double precision");

                    b.Property<int?>("session_count")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("start_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("GMSBackend.Entities.ProductCodingInfo", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long?>("coding_parent_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("product_coding_infos");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoiceDetails", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<long>("invoice_id")
                        .HasColumnType("bigint");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("memo")
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.Property<string>("product_name")
                        .HasColumnType("text");

                    b.Property<int>("qty")
                        .HasColumnType("integer");

                    b.Property<short?>("reduction_percent")
                        .HasColumnType("smallint");

                    b.Property<double?>("reduction_price")
                        .HasColumnType("double precision");

                    b.Property<int>("session_qty")
                        .HasColumnType("integer");

                    b.Property<int>("session_reserved")
                        .HasColumnType("integer");

                    b.Property<int>("session_used")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("invoice_id");

                    b.HasIndex("product_id");

                    b.ToTable("sale_invoice_details");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoiceHeader", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<long>("account_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("create_date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("inv_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<short>("inv_type")
                        .HasColumnType("smallint");

                    b.Property<bool>("is_deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("memo")
                        .HasColumnType("text");

                    b.Property<double?>("price")
                        .HasColumnType("double precision");

                    b.Property<double?>("reduction")
                        .HasColumnType("double precision");

                    b.Property<long?>("visitor_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("account_id");

                    b.ToTable("sale_invoice_headers");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoicePayment", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("create_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<long>("invoice_id")
                        .HasColumnType("bigint");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<int>("sale_invoice_payment_type_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("invoice_id");

                    b.HasIndex("sale_invoice_payment_type_id");

                    b.ToTable("sale_invoice_payments");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoicePaymentType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("sale_invoice_payment_types");
                });

            modelBuilder.Entity("GMSBackend.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("user_role_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("user_name")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("GMSBackend.Entities.UserRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("id");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("GMSBackend.Entities.AccTransaction", b =>
                {
                    b.HasOne("GMSBackend.Entities.Account", "account")
                        .WithMany()
                        .HasForeignKey("AccountID");

                    b.HasOne("GMSBackend.Entities.AccountType", "account_type")
                        .WithMany()
                        .HasForeignKey("AccountTypeID");

                    b.Navigation("account");

                    b.Navigation("account_type");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoiceDetails", b =>
                {
                    b.HasOne("GMSBackend.Entities.SaleInvoiceHeader", "sale_invoice_header")
                        .WithMany("sale_invoice_details")
                        .HasForeignKey("invoice_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMSBackend.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("sale_invoice_header");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoiceHeader", b =>
                {
                    b.HasOne("GMSBackend.Entities.Account", "account")
                        .WithMany()
                        .HasForeignKey("account_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoicePayment", b =>
                {
                    b.HasOne("GMSBackend.Entities.SaleInvoiceHeader", "sale_invoice_header")
                        .WithMany("sale_invoice_payments")
                        .HasForeignKey("invoice_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GMSBackend.Entities.SaleInvoicePaymentType", "sale_invoice_payment_type")
                        .WithMany()
                        .HasForeignKey("sale_invoice_payment_type_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sale_invoice_header");

                    b.Navigation("sale_invoice_payment_type");
                });

            modelBuilder.Entity("GMSBackend.Entities.SaleInvoiceHeader", b =>
                {
                    b.Navigation("sale_invoice_details");

                    b.Navigation("sale_invoice_payments");
                });
#pragma warning restore 612, 618
        }
    }
}

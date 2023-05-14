﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamContext))]
    partial class ExamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Banque", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Banque");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Compte", b =>
                {
                    b.Property<string>("NumeroCompte")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("BanqueCode")
                        .HasColumnType("int");

                    b.Property<int>("BanqueFk")
                        .HasColumnType("int");

                    b.Property<string>("Propriétaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Solde")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("NumeroCompte");

                    b.HasIndex("BanqueCode");

                    b.ToTable("Compte");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.DAB", b =>
                {
                    b.Property<string>("DabId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DabId");

                    b.ToTable("DAB");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Exemple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Exemple");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Transaction", b =>
                {
                    b.Property<string>("NumeroCompteFk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DABFk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Montant")
                        .HasColumnType("float");

                    b.HasKey("NumeroCompteFk", "DABFk", "Date");

                    b.HasIndex("DABFk");

                    b.ToTable("Transaction");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionRetrait", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Transaction");

                    b.Property<bool>("AutreAgence")
                        .HasColumnType("bit");

                    b.ToTable("TransactionRetrait", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionTransfert", b =>
                {
                    b.HasBaseType("Examen.ApplicationCore.Domain.Transaction");

                    b.Property<string>("NumeroCompte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("TransactionTransfert", (string)null);
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Compte", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Banque", null)
                        .WithMany("Comptes")
                        .HasForeignKey("BanqueCode");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Transaction", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.DAB", "Dab")
                        .WithMany("Transactions")
                        .HasForeignKey("DABFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Compte", "Compte")
                        .WithMany("Transactions")
                        .HasForeignKey("NumeroCompteFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("Dab");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionRetrait", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Examen.ApplicationCore.Domain.TransactionRetrait", "NumeroCompteFk", "DABFk", "Date")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.TransactionTransfert", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Examen.ApplicationCore.Domain.TransactionTransfert", "NumeroCompteFk", "DABFk", "Date")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Banque", b =>
                {
                    b.Navigation("Comptes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Compte", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.DAB", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}

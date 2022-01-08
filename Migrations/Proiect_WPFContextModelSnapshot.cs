﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_WPF.Data;

namespace Proiect_WPF.Migrations
{
    [DbContext(typeof(Proiect_WPFContext))]
    partial class Proiect_WPFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proiect_WPF.Models.Bilet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("ZborID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Bilet");
                });

            modelBuilder.Entity("Proiect_WPF.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data_nasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nr_zboruri")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Proiect_WPF.Models.TicketFlight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BiletID")
                        .HasColumnType("int");

                    b.Property<int>("ZborID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BiletID");

                    b.HasIndex("ZborID");

                    b.ToTable("TicketFlight");
                });

            modelBuilder.Entity("Proiect_WPF.Models.Zbor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Durata")
                        .HasColumnType("int");

                    b.Property<string>("PlecareID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.ToTable("Zbor");
                });

            modelBuilder.Entity("Proiect_WPF.Models.Bilet", b =>
                {
                    b.HasOne("Proiect_WPF.Models.Client", "Client")
                        .WithMany("Bilet")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Proiect_WPF.Models.TicketFlight", b =>
                {
                    b.HasOne("Proiect_WPF.Models.Bilet", "Bilet")
                        .WithMany("TicketFlights")
                        .HasForeignKey("BiletID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_WPF.Models.Zbor", "Zbor")
                        .WithMany("TicketFlights")
                        .HasForeignKey("ZborID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bilet");

                    b.Navigation("Zbor");
                });

            modelBuilder.Entity("Proiect_WPF.Models.Bilet", b =>
                {
                    b.Navigation("TicketFlights");
                });

            modelBuilder.Entity("Proiect_WPF.Models.Client", b =>
                {
                    b.Navigation("Bilet");
                });

            modelBuilder.Entity("Proiect_WPF.Models.Zbor", b =>
                {
                    b.Navigation("TicketFlights");
                });
#pragma warning restore 612, 618
        }
    }
}

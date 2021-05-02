﻿// <auto-generated />
using System;
using Football.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Football.DAL.Migrations
{
    [DbContext(typeof(FootballContext))]
    [Migration("20210103224140_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Football.DAL.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<double>("Budget")
                        .HasColumnType("float")
                        .HasColumnName("budget");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("country");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("YearFounded")
                        .HasColumnType("int")
                        .HasColumnName("year_founded");

                    b.HasKey("Id");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("Football.DAL.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Club_Enemy_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Club_Id")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Team1_Goals")
                        .HasColumnType("int");

                    b.Property<int>("Team2_Goals")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Club_Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Football.DAL.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Club_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Contract_Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsCaptain")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasDefaultValue("CM");

                    b.HasKey("Id");

                    b.HasIndex("Club_Id");

                    b.HasIndex("Contract_Id")
                        .IsUnique()
                        .HasFilter("[Contract_Id] IS NOT NULL");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Football.DAL.Entities.PlayerContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Premium")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<DateTime>("SignedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Football.DAL.Entities.PlayerMatch", b =>
                {
                    b.Property<int>("Player_Id")
                        .HasColumnType("int");

                    b.Property<int>("Match_Id")
                        .HasColumnType("int");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.HasKey("Player_Id", "Match_Id");

                    b.HasIndex("Match_Id");

                    b.ToTable("PlayerMatches");
                });

            modelBuilder.Entity("Football.DAL.Entities.Match", b =>
                {
                    b.HasOne("Football.DAL.Entities.Club", "Club")
                        .WithMany("Matches")
                        .HasForeignKey("Club_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Football.DAL.Entities.Player", b =>
                {
                    b.HasOne("Football.DAL.Entities.Club", "Club")
                        .WithMany("Players")
                        .HasForeignKey("Club_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Football.DAL.Entities.PlayerContract", "Contract")
                        .WithOne("Player")
                        .HasForeignKey("Football.DAL.Entities.Player", "Contract_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Club");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Football.DAL.Entities.PlayerMatch", b =>
                {
                    b.HasOne("Football.DAL.Entities.Match", "Match")
                        .WithMany("PlayerMatches")
                        .HasForeignKey("Match_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Football.DAL.Entities.Player", "Player")
                        .WithMany("PlayerMatches")
                        .HasForeignKey("Player_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Football.DAL.Entities.Club", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("Football.DAL.Entities.Match", b =>
                {
                    b.Navigation("PlayerMatches");
                });

            modelBuilder.Entity("Football.DAL.Entities.Player", b =>
                {
                    b.Navigation("PlayerMatches");
                });

            modelBuilder.Entity("Football.DAL.Entities.PlayerContract", b =>
                {
                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}

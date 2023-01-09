﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230109093909_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MatchUser", b =>
                {
                    b.Property<int>("MatchesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("MatchesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("MatchUser");
                });

            modelBuilder.Entity("Model.Bar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("bars");
                });

            modelBuilder.Entity("Model.City", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("UserId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Model.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BarId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BarId");

                    b.ToTable("drinks");
                });

            modelBuilder.Entity("Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityName");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("Model.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("matches");
                });

            modelBuilder.Entity("Model.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaximumpreferredAge")
                        .HasColumnType("int");

                    b.Property<int>("MinimumpreferredAge")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MatchUser", b =>
                {
                    b.HasOne("Model.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Model.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Model.Bar", b =>
                {
                    b.HasOne("Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Model.City", b =>
                {
                    b.HasOne("Model.User", null)
                        .WithMany("Cities")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Model.Drink", b =>
                {
                    b.HasOne("Model.Bar", null)
                        .WithMany("Drinks")
                        .HasForeignKey("BarId");
                });

            modelBuilder.Entity("Model.Location", b =>
                {
                    b.HasOne("Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityName");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Model.Message", b =>
                {
                    b.HasOne("Model.Match", null)
                        .WithMany("Messages")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.HasOne("Model.User", null)
                        .WithMany("LikedUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Model.Bar", b =>
                {
                    b.Navigation("Drinks");
                });

            modelBuilder.Entity("Model.Match", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("LikedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

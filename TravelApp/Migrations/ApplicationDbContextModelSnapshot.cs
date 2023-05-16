﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApp.TravelApp;

#nullable disable

namespace TravelApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.14");

            modelBuilder.Entity("TravelApp.TravelApp.Models.TravelInfoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlanModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Xid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlanModelId");

                    b.ToTable("TravelInfos");
                });

            modelBuilder.Entity("TravelApp.TravelApp.Models.TravelPlanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TripStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TravelPlans");
                });

            modelBuilder.Entity("TravelApp.TravelApp.Models.TravelInfoModel", b =>
                {
                    b.HasOne("TravelApp.TravelApp.Models.TravelPlanModel", "PlanModel")
                        .WithMany("TravelInfos")
                        .HasForeignKey("PlanModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanModel");
                });

            modelBuilder.Entity("TravelApp.TravelApp.Models.TravelPlanModel", b =>
                {
                    b.Navigation("TravelInfos");
                });
#pragma warning restore 612, 618
        }
    }
}

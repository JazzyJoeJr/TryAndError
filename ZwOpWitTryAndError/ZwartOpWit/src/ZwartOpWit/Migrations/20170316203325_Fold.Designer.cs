using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ZwartOpWit.Models;

namespace ZwartOpWit.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20170316203325_Fold")]
    partial class Fold
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("ZwartOpWit.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ZwartOpWit.Models.Fold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Heigth");

                    b.Property<int>("JobNumber");

                    b.Property<int>("Quantity");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.ToTable("Fold");
                });

            modelBuilder.Entity("ZwartOpWit.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Machine");
                });

            modelBuilder.Entity("ZwartOpWit.Models.Stitch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cover");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<int>("Heigth");

                    b.Property<int>("JobNumber");

                    b.Property<int>("MachineId");

                    b.Property<int>("PageQuantity");

                    b.Property<string>("PaperBw");

                    b.Property<string>("PaperCover");

                    b.Property<int>("Quantity");

                    b.Property<DateTime>("StartDateTime");

                    b.Property<DateTime>("StopDateTime");

                    b.Property<int>("UserId");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("UserId");

                    b.ToTable("Stitch");
                });

            modelBuilder.Entity("ZwartOpWit.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ZwartOpWit.Models.Machine", b =>
                {
                    b.HasOne("ZwartOpWit.Models.Department", "Department")
                        .WithMany("Machines")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ZwartOpWit.Models.Stitch", b =>
                {
                    b.HasOne("ZwartOpWit.Models.Machine", "Machine")
                        .WithMany("Stiches")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ZwartOpWit.Models.User", "User")
                        .WithMany("Stitches")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

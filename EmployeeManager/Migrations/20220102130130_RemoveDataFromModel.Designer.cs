﻿// <auto-generated />
using System;
using EmployeeManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220102130130_RemoveDataFromModel")]
    partial class RemoveDataFromModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManager.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManager.Models.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProject");
                });

            modelBuilder.Entity("EmployeeManager.Models.JobHistory", b =>
                {
                    b.Property<int>("JobHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("JobHistoryId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("PositionId");

                    b.ToTable("JobHistories");
                });

            modelBuilder.Entity("EmployeeManager.Models.JobHistoryPosition", b =>
                {
                    b.Property<int>("JobHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("JobHistoryId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("JobHistoryPosition");
                });

            modelBuilder.Entity("EmployeeManager.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("ManagerId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("EmployeeManager.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EmployeeManager.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmployeeManager.Models.Employee", b =>
                {
                    b.HasOne("EmployeeManager.Models.Manager", "Manager")
                        .WithMany("Employees")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManager.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.Navigation("Manager");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("EmployeeManager.Models.EmployeeProject", b =>
                {
                    b.HasOne("EmployeeManager.Models.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManager.Models.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("EmployeeManager.Models.JobHistory", b =>
                {
                    b.HasOne("EmployeeManager.Models.Employee", "Employee")
                        .WithOne("JobHistory")
                        .HasForeignKey("EmployeeManager.Models.JobHistory", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManager.Models.Position", null)
                        .WithMany("JobHistories")
                        .HasForeignKey("PositionId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeManager.Models.JobHistoryPosition", b =>
                {
                    b.HasOne("EmployeeManager.Models.JobHistory", "JobHistory")
                        .WithMany()
                        .HasForeignKey("JobHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManager.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobHistory");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("EmployeeManager.Models.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");

                    b.Navigation("JobHistory");
                });

            modelBuilder.Entity("EmployeeManager.Models.Manager", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("EmployeeManager.Models.Position", b =>
                {
                    b.Navigation("JobHistories");
                });

            modelBuilder.Entity("EmployeeManager.Models.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}

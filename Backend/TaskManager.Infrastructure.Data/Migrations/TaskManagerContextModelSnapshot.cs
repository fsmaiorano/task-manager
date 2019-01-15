﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TaskManager.Infrastructure.Data.Context;

namespace TaskManager.Infrastructure.Data.Migrations
{
    [DbContext(typeof(TaskManagerContext))]
    partial class TaskManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TaskManager.Domain.Entities.BoardEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserEntityId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("TaskManager.Domain.Entities.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("BoardId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManager.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Password");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("UrlPhoto")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreatedAt = new DateTime(2019, 1, 15, 12, 22, 15, 613, DateTimeKind.Local).AddTicks(9793),
                            Email = "root@root.com",
                            Name = "root",
                            Password = "123",
                            Surname = "root",
                            UpdatedAt = new DateTime(2019, 1, 15, 12, 22, 15, 613, DateTimeKind.Local).AddTicks(9860),
                            UrlPhoto = ""
                        });
                });

            modelBuilder.Entity("TaskManager.Domain.Entities.UserGroupEntity", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BoardId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("IsAdministrator");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId", "BoardId");

                    b.HasIndex("BoardId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("TaskManager.Domain.Entities.BoardEntity", b =>
                {
                    b.HasOne("TaskManager.Domain.Entities.UserEntity")
                        .WithMany("Boards")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("TaskManager.Domain.Entities.TaskEntity", b =>
                {
                    b.HasOne("TaskManager.Domain.Entities.BoardEntity", "Board")
                        .WithMany("Tasks")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaskManager.Domain.Entities.UserGroupEntity", b =>
                {
                    b.HasOne("TaskManager.Domain.Entities.BoardEntity", "Board")
                        .WithMany("UserGroups")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaskManager.Domain.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

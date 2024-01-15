﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagement.Persistence.Context;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    [DbContext(typeof(TaskManagementDbContext))]
    [Migration("20240112173934_adjustPK")]
    partial class adjustPK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManagement.Domain.Entities.DomainUserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamMembersEntityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamMembersEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AttachFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("LastModifiedUserId")
                        .HasColumnType("int");

                    b.Property<int>("TaskLevelId")
                        .HasColumnType("int");

                    b.Property<int>("TaskPriorityId")
                        .HasColumnType("int");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TaskLevelId");

                    b.HasIndex("TaskPriorityId");

                    b.HasIndex("TaskStatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskLevelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("LastModifiedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaskLevels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Easy"
                        },
                        new
                        {
                            Id = 2,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Difficult"
                        });
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskPriorityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("LastModifiedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaskPriorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Low"
                        },
                        new
                        {
                            Id = 2,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "High"
                        },
                        new
                        {
                            Id = 4,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Urgent"
                        });
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("LastModifiedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TaskStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "NotStarted"
                        },
                        new
                        {
                            Id = 2,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Started"
                        },
                        new
                        {
                            Id = 3,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 4,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Failed"
                        },
                        new
                        {
                            Id = 5,
                            CreateUserId = 0,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            LastModifiedUserId = 0,
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team.TeamEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("LastModifiedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team.TeamMembersEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("LastModifiedUserId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.DomainUserEntity", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.Team.TeamMembersEntity", null)
                        .WithMany("Users")
                        .HasForeignKey("TeamMembersEntityId");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskEntity", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.Task.TaskLevelEntity", "TaskLevelEntity")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tasks_TaskLevels_TaskLevelId");

                    b.HasOne("TaskManagement.Domain.Entities.Task.TaskPriorityEntity", "TaskPriorityEntity")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskPriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tasks_TaskPriorities_TaskPriorityId");

                    b.HasOne("TaskManagement.Domain.Entities.Task.TaskStatusEntity", "TaskStatusEntity")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tasks_TaskStatuses_TaskStatusId");

                    b.Navigation("TaskLevelEntity");

                    b.Navigation("TaskPriorityEntity");

                    b.Navigation("TaskStatusEntity");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team.TeamMembersEntity", b =>
                {
                    b.HasOne("TaskManagement.Domain.Entities.Team.TeamEntity", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagement.Domain.Entities.DomainUserEntity", "User")
                        .WithMany("TeamMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.DomainUserEntity", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskLevelEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskPriorityEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Task.TaskStatusEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team.TeamEntity", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("TaskManagement.Domain.Entities.Team.TeamMembersEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

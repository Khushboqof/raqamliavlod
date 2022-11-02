﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RaqamliAvlod.DataAccess.DbContexts;

#nullable disable

namespace RaqamliAvlod.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221102145829_LastMigration")]
    partial class LastMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Contests.Contest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CalculatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Contests");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Contests.ContestStandings", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ContestId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Penalty")
                        .HasColumnType("integer");

                    b.Property<int>("ResultCoins")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("UserId", "ContestId")
                        .IsUnique();

                    b.ToTable("ContestStandings");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Contests.ContestSubmissionsInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ContestStandingsId")
                        .HasColumnType("bigint");

                    b.Property<TimeOnly>("FixedTime")
                        .HasColumnType("time without time zone");

                    b.Property<bool>("IsFixed")
                        .HasColumnType("boolean");

                    b.Property<short>("PenaltySubmissions")
                        .HasColumnType("smallint");

                    b.Property<long>("ProblemSetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContestStandingsId");

                    b.HasIndex("ProblemSetId", "ContestStandingsId")
                        .IsUnique();

                    b.ToTable("ContestSubmissionsInfos");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Courses.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Courses.CourseComment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("OwnerId");

                    b.ToTable("CourseComments");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Courses.CourseVideo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.Property<string>("YouTubeLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("YouTubeThumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId", "YouTubeLink")
                        .IsUnique();

                    b.ToTable("CourseVideos");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<short>("ContestCoins")
                        .HasColumnType("smallint");

                    b.Property<long?>("ContestId")
                        .HasColumnType("bigint");

                    b.Property<char>("ContestIdentifier")
                        .HasColumnType("character(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("Difficulty")
                        .HasColumnType("smallint");

                    b.Property<string>("InputDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean");

                    b.Property<int>("MemoryLimit")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OutputDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("ContestIdentifier", "ContestId")
                        .IsUnique();

                    b.ToTable("ProblemSets");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSetTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Input")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Output")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ProblemSetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProblemSetId");

                    b.ToTable("ProblemSetTests");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.QuestionAnswer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("HasReplied")
                        .HasColumnType("boolean");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.QuestionTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TagId", "QuestionId")
                        .IsUnique();

                    b.ToTable("QuestionTags");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TagName")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Submissions.Submission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("ContestId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ExecutionTime")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LengthOfCode")
                        .HasColumnType("integer");

                    b.Property<int>("MemoryUsage")
                        .HasColumnType("integer");

                    b.Property<long>("ProblemSetId")
                        .HasColumnType("bigint");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("ProblemSetId");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ContestCoins")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProblemSetCoins")
                        .HasColumnType("integer");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ImagePath")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("Salt")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Contests.ContestStandings", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Contests.Contest", "Contest")
                        .WithMany()
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Contests.ContestSubmissionsInfo", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Contests.ContestStandings", "ContestStandings")
                        .WithMany()
                        .HasForeignKey("ContestStandingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSet", "ProblemSet")
                        .WithMany()
                        .HasForeignKey("ProblemSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContestStandings");

                    b.Navigation("ProblemSet");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Courses.Course", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Courses.CourseComment", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Courses.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Courses.CourseVideo", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Courses.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSet", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Contests.Contest", "Contest")
                        .WithMany()
                        .HasForeignKey("ContestId");

                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contest");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSetTest", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSet", "ProblemSet")
                        .WithMany()
                        .HasForeignKey("ProblemSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProblemSet");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.Question", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.QuestionAnswer", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaqamliAvlod.Domain.Entities.Questions.QuestionAnswer", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("RaqamliAvlod.Domain.Entities.Questions.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Parent");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Questions.QuestionTag", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Questions.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaqamliAvlod.Domain.Entities.Questions.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RaqamliAvlod.Domain.Entities.Submissions.Submission", b =>
                {
                    b.HasOne("RaqamliAvlod.Domain.Entities.Contests.Contest", "Contest")
                        .WithMany()
                        .HasForeignKey("ContestId");

                    b.HasOne("RaqamliAvlod.Domain.Entities.ProblemSets.ProblemSet", "ProblemSet")
                        .WithMany()
                        .HasForeignKey("ProblemSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RaqamliAvlod.Domain.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contest");

                    b.Navigation("ProblemSet");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

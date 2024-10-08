﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TheSecondTestSolution.Infrastructure.Database;

#nullable disable

namespace TheSecondTestSolution.Infrastructure.Migrations
{
    [DbContext(typeof(TopicDbContext))]
    partial class TopicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("topics")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TheSecondTestSolution.Domain.Entities.TopicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("Type");

                    b.HasIndex("UserName");

                    b.ToTable("Topics", "topics");
                });

            modelBuilder.Entity("TheSecondTestSolution.Domain.Entities.TopicEntity", b =>
                {
                    b.OwnsOne("TheSecondTestSolution.Domain.ValueObjects.LinkValueObject", "Link", b1 =>
                        {
                            b1.Property<int>("TopicEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("TopicEntityId");

                            b1.ToTable("Topics", "topics");

                            b1.WithOwner()
                                .HasForeignKey("TopicEntityId");
                        });

                    b.OwnsOne("TheSecondTestSolution.Domain.ValueObjects.ScoreValueObject", "Score", b1 =>
                        {
                            b1.Property<int>("TopicEntityId")
                                .HasColumnType("integer");

                            b1.Property<int>("Value")
                                .HasColumnType("integer");

                            b1.HasKey("TopicEntityId");

                            b1.ToTable("Topics", "topics");

                            b1.WithOwner()
                                .HasForeignKey("TopicEntityId");
                        });

                    b.Navigation("Link")
                        .IsRequired();

                    b.Navigation("Score")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

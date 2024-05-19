﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QueryBank.Infrastructure.Persistence;

#nullable disable

namespace QueryBank.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240430225919_AddTableSkill")]
    partial class AddTableSkill
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QueryBank.Infrastructure.Persistence.Models.SkillModel", b =>
                {
                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid")
                        .HasColumnName("skl_skill_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("deleted_at");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean")
                        .HasColumnName("skl_disabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("skl_name");

                    b.Property<Guid?>("SubSkillId")
                        .HasColumnType("uuid")
                        .HasColumnName("skl_sub_skill_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("SkillId");

                    b.HasIndex("SubSkillId", "Name")
                        .IsUnique();

                    b.ToTable("skill");
                });

            modelBuilder.Entity("QueryBank.Infrastructure.Persistence.Models.SkillModel", b =>
                {
                    b.HasOne("QueryBank.Infrastructure.Persistence.Models.SkillModel", "SubSkill")
                        .WithMany("ParentSkills")
                        .HasForeignKey("SubSkillId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SubSkill");
                });

            modelBuilder.Entity("QueryBank.Infrastructure.Persistence.Models.SkillModel", b =>
                {
                    b.Navigation("ParentSkills");
                });
#pragma warning restore 612, 618
        }
    }
}

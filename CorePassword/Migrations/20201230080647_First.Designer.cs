﻿// <auto-generated />
using System;
using CorePassword.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CorePassword.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20201230080647_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CorePassword.Data.WebsitePassword", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CopyCount")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebsitePassword");
                });

            modelBuilder.Entity("CorePassword.Data.WebsitePasswordHistory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebsitePasswordId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("WebsitePasswordId");

                    b.ToTable("WebsitePasswordHistory");
                });

            modelBuilder.Entity("CorePassword.Data.WebsitePasswordHistory", b =>
                {
                    b.HasOne("CorePassword.Data.WebsitePassword", "WebsitePassword")
                        .WithMany("PasswordHistories")
                        .HasForeignKey("WebsitePasswordId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.Navigation("WebsitePassword");
                });

            modelBuilder.Entity("CorePassword.Data.WebsitePassword", b =>
                {
                    b.Navigation("PasswordHistories");
                });
#pragma warning restore 612, 618
        }
    }
}

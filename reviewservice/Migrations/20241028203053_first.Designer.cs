﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using domain;

#nullable disable

namespace reviewservice.Migrations
{
    [DbContext(typeof(DogmateMarketplaceContext))]
    [Migration("20241028203053_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("domain.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("review_id");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("review_date");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int")
                        .HasColumnName("seller_id");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("service_id");

                    b.HasKey("ReviewId")
                        .HasName("PRIMARY");

                    b.ToTable("reviews", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
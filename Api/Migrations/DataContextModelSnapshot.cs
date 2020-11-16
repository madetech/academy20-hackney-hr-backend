﻿// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Api.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("contact_email")
                        .HasColumnType("text");

                    b.Property<long>("contact_number")
                        .HasColumnType("bigint");

                    b.Property<string>("first_name")
                        .HasColumnType("text");

                    b.Property<string>("home_address_city")
                        .HasColumnType("text");

                    b.Property<string>("home_address_line_1")
                        .HasColumnType("text");

                    b.Property<string>("home_address_line_2")
                        .HasColumnType("text");

                    b.Property<string>("home_address_postcode")
                        .HasColumnType("text");

                    b.Property<string>("job_title")
                        .HasColumnType("text");

                    b.Property<string>("last_name")
                        .HasColumnType("text");

                    b.Property<string>("manager")
                        .HasColumnType("text");

                    b.Property<long>("next_of_kin_contact_number")
                        .HasColumnType("bigint");

                    b.Property<string>("next_of_kin_first_name")
                        .HasColumnType("text");

                    b.Property<string>("next_of_kin_last_name")
                        .HasColumnType("text");

                    b.Property<string>("office_location")
                        .HasColumnType("text");

                    b.Property<string>("reportees")
                        .HasColumnType("text");

                    b.Property<string>("salary_band")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}

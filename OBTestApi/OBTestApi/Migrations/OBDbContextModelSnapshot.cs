﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBTestApi.DbModels;

namespace OBTestApi.Migrations
{
    [DbContext(typeof(OBDbContext))]
    partial class OBDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OBTestApi.DbModels.Patient", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmputationLevel");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("HasOBDevice");

                    b.Property<string>("LastName");

                    b.Property<int>("Mobis");

                    b.Property<string>("ProfileImage");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });
#pragma warning restore 612, 618
        }
    }
}

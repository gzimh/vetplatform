﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetPlatform.Data;

namespace VetPlatform.Data.Migrations
{
    [DbContext(typeof(TenantContext))]
    partial class TenantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VetPlatform.Data.Models.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HostName");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37ef41bd-b7ed-4fa2-bef8-916b03b1e174"),
                            HostName = "pets.vetplatform.local",
                            Name = "Pets Clinic"
                        },
                        new
                        {
                            Id = new Guid("85029b8d-86f1-4c81-befc-a832819ad557"),
                            HostName = "meds.vetplatform.local",
                            Name = "Meds Clinic"
                        },
                        new
                        {
                            Id = new Guid("fe0024a5-5d18-4b2e-b2eb-59a0f42d1861"),
                            HostName = "localhost",
                            Name = "Dev"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Valtegy.Repository.Context;

namespace Valtegy.Repository.Migrations
{
    [DbContext(typeof(ValtegyDbContext))]
    partial class ValtegyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Valtegy.Domain.Entities.Activities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("ActivityDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ActivityNumber")
                        .HasColumnType("int");

                    b.Property<int>("ActivityTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Hours")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("InsertDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastUpdate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusActivityId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserIdCreated")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserIdUpdated")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Valtegy.Domain.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName2")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ModifyUserId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValidateEmailCode")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("ValidateNewEmailCode")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("ValidateNewPhoneNumberCode")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("ValidatePhoneNumberCode")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

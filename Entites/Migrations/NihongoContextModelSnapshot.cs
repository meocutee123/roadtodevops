﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nihongo.Entites.Models;

namespace Nihongo.Entites.Migrations
{
    [DbContext(typeof(NihongoContext))]
    partial class NihongoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageProperty", b =>
                {
                    b.Property<int>("ImagesId")
                        .HasColumnType("int");

                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.HasKey("ImagesId", "PropertiesId");

                    b.HasIndex("PropertiesId");

                    b.ToTable("ImageProperty");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingAge")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Landlord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PreferredContactMethod")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Landlords");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BathCount")
                        .HasColumnType("int");

                    b.Property<int?>("BuildingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("HighLights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LandlordId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("LandlordId");

                    b.HasIndex("LastModifiedBy");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("ImageProperty", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Image", null)
                        .WithMany()
                        .HasForeignKey("ImagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nihongo.Entites.Models.Property", null)
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Account", b =>
                {
                    b.OwnsMany("Nihongo.Entites.Models.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Building", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Account", "CreatedByAccount")
                        .WithMany("BuildingsCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nihongo.Entites.Models.Account", "ModifiedByAccount")
                        .WithMany("BuildingsModifiedBy")
                        .HasForeignKey("LastModifiedBy");

                    b.Navigation("CreatedByAccount");

                    b.Navigation("ModifiedByAccount");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Landlord", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Account", "CreatedByAccount")
                        .WithMany("LandlordsCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nihongo.Entites.Models.Account", "ModifiedByAccount")
                        .WithMany("LandlordsModifiedBy")
                        .HasForeignKey("LastModifiedBy");

                    b.OwnsMany("Nihongo.Entites.Models.LandlordOtherDetail", "LandlordOtherDetail", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FieldAlias")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Label")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("LandlordId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("LandlordId");

                            b1.ToTable("LandlordOtherDetail");

                            b1.WithOwner()
                                .HasForeignKey("LandlordId");
                        });

                    b.Navigation("CreatedByAccount");

                    b.Navigation("LandlordOtherDetail");

                    b.Navigation("ModifiedByAccount");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Property", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Building", "Building")
                        .WithMany("Properties")
                        .HasForeignKey("BuildingId");

                    b.HasOne("Nihongo.Entites.Models.Account", "CreatedByAccount")
                        .WithMany("PropertiesCreatedBy")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nihongo.Entites.Models.Landlord", "Landlord")
                        .WithMany("Properties")
                        .HasForeignKey("LandlordId");

                    b.HasOne("Nihongo.Entites.Models.Account", "ModifiedByAccount")
                        .WithMany("PropertiesModifiedBy")
                        .HasForeignKey("LastModifiedBy");

                    b.OwnsMany("Nihongo.Entites.Models.PropertyAdditionalInformation", "AdditionalInformation", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FieldAlias")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Label")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PropertyId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("PropertyId");

                            b1.ToTable("PropertyAdditionalInformation");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.OwnsMany("Nihongo.Entites.Models.PropertyAmenity", "Amenities", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FieldAlias")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Label")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PropertyId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("PropertyId");

                            b1.ToTable("PropertyAmenity");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.OwnsMany("Nihongo.Entites.Models.PropertyOtherFeature", "OtherFeatures", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FieldAlias")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Label")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PropertyId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("PropertyId");

                            b1.ToTable("PropertyOtherFeature");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.Navigation("AdditionalInformation");

                    b.Navigation("Amenities");

                    b.Navigation("Building");

                    b.Navigation("CreatedByAccount");

                    b.Navigation("Landlord");

                    b.Navigation("ModifiedByAccount");

                    b.Navigation("OtherFeatures");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Account", b =>
                {
                    b.Navigation("BuildingsCreatedBy");

                    b.Navigation("BuildingsModifiedBy");

                    b.Navigation("LandlordsCreatedBy");

                    b.Navigation("LandlordsModifiedBy");

                    b.Navigation("PropertiesCreatedBy");

                    b.Navigation("PropertiesModifiedBy");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Building", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Landlord", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nihongo.Entites.Models;

namespace Nihongo.Entites.Migrations
{
    [DbContext(typeof(NihongoContext))]
    [Migration("20220310033259_change_property-add-some-new-tables")]
    partial class change_propertyaddsomenewtables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nihongo.Entites.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
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

                    b.Property<int>("LandlordId")
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

                    b.HasIndex("LandlordId");

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

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("HighLight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyType")
                        .HasColumnType("int");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.PropertyAmenity", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("PropertyAmenities");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.PropertyImage", b =>
                {
                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId", "ImageId");

                    b.HasIndex("ImageId");

                    b.ToTable("PropertyImages");
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
                    b.HasOne("Nihongo.Entites.Models.Landlord", "Landlord")
                        .WithMany("Buildings")
                        .HasForeignKey("LandlordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Landlord");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Landlord", b =>
                {
                    b.OwnsMany("Nihongo.Entites.Models.LandlordOtherDetail", "LandlordOtherDetail", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Key")
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

                    b.Navigation("LandlordOtherDetail");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Property", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Building", "Building")
                        .WithMany("Properties")
                        .HasForeignKey("BuildingId");

                    b.OwnsMany("Nihongo.Entites.Models.OtherFeature", "OtherFeatures", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("PropertyId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PropertyId");

                            b1.ToTable("OtherFeature");

                            b1.WithOwner()
                                .HasForeignKey("PropertyId");
                        });

                    b.OwnsMany("Nihongo.Entites.Models.PropertyAdditionalInformation", "AdditionalInformation", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Key")
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

                    b.Navigation("AdditionalInformation");

                    b.Navigation("Building");

                    b.Navigation("OtherFeatures");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.PropertyAmenity", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Amenity", "Amenity")
                        .WithMany("Properties")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nihongo.Entites.Models.Property", "Property")
                        .WithMany("Amenities")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.PropertyImage", b =>
                {
                    b.HasOne("Nihongo.Entites.Models.Image", "Image")
                        .WithMany("Properties")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nihongo.Entites.Models.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Amenity", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Building", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Image", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Landlord", b =>
                {
                    b.Navigation("Buildings");
                });

            modelBuilder.Entity("Nihongo.Entites.Models.Property", b =>
                {
                    b.Navigation("Amenities");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}

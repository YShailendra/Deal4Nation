﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Products.Context;
using System;

namespace Products.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.Models.BrandModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<bool?>("isFav");

                    b.HasKey("ID");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Products.Models.CategoryModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CatPID");

                    b.Property<int>("CatType");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<bool?>("isFav");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Products.Models.DealModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("Url");

                    b.Property<bool?>("isFav");

                    b.HasKey("ID");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("Products.Models.FavouriteModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("OfferId");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<Guid>("UserId");

                    b.HasKey("ID");

                    b.ToTable("Favourite");
                });

            modelBuilder.Entity("Products.Models.ImageModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("RefrenceID");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Products.Models.MarketPlaceModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.ToTable("MarketPlace");
                });

            modelBuilder.Entity("Products.Models.OfferModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BrandID");

                    b.Property<string>("Cashback");

                    b.Property<Guid>("CategoryID");

                    b.Property<string>("CouponCode");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("EndOn");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ShortDescription");

                    b.Property<DateTime?>("StartOn");

                    b.Property<Guid?>("StoreID");

                    b.Property<Guid>("StroreID");

                    b.Property<Guid?>("SubCategoryID");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("StoreID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Products.Models.StoreModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<bool?>("isFav");

                    b.HasKey("ID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Products.Models.UserModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Addr");

                    b.Property<int?>("Balance");

                    b.Property<string>("City");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DeviceID");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNo")
                        .IsRequired();

                    b.Property<string>("Profession");

                    b.Property<string>("Refrrel");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNo")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("Products.Models.OfferModel", b =>
                {
                    b.HasOne("Products.Models.BrandModel", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Products.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Products.Models.StoreModel", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID");
                });
#pragma warning restore 612, 618
        }
    }
}

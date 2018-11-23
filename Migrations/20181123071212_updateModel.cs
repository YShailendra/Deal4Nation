using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CatPID = table.Column<Guid>(nullable: true),
                    CatType = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Favourite",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    OfferId = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourite", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    RefrenceID = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MarketPlace",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPlace", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Addr = table.Column<string>(nullable: true),
                    Balance = table.Column<int>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeviceID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    Profession = table.Column<string>(nullable: true),
                    Refrrel = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BrandID = table.Column<Guid>(nullable: false),
                    Cashback = table.Column<string>(nullable: true),
                    CategoryID = table.Column<Guid>(nullable: false),
                    CouponCode = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EndOn = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    StartOn = table.Column<DateTime>(nullable: true),
                    SubCategoryID = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offers_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BrandID",
                table: "Offers",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CategoryID",
                table: "Offers",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PhoneNo",
                table: "User",
                column: "PhoneNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Favourite");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "MarketPlace");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

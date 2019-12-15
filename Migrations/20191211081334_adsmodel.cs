using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class adsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategory",
                table: "Ads",
                newName: "SubCategoryID");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Ads",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Ads",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Ads",
                newName: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CategoryID",
                table: "Ads",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_SubCategoryID",
                table: "Ads",
                column: "SubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryID",
                table: "Ads",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_SubCategoryID",
                table: "Ads",
                column: "SubCategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryID",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_SubCategoryID",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_CategoryID",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_SubCategoryID",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Ads",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "Ads",
                newName: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Ads",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Ads",
                newName: "Category");
        }
    }
}

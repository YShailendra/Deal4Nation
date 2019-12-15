using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Product",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "Descriptions",
                table: "Product",
                newName: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryID",
                table: "Product",
                column: "SubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_SubCategoryID",
                table: "Product",
                column: "SubCategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_SubCategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubCategoryID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Product",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Product",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "Descriptions");
        }
    }
}

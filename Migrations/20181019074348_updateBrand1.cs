using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class updateBrand1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Images_LogoID",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_LogoID",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LogoID",
                table: "Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LogoID",
                table: "Brand",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_LogoID",
                table: "Brand",
                column: "LogoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Images_LogoID",
                table: "Brand",
                column: "LogoID",
                principalTable: "Images",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

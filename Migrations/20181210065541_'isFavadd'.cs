using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class isFavadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFav",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFav",
                table: "Deals",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFav",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isFav",
                table: "Brand",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFav",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "isFav",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "isFav",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "isFav",
                table: "Brand");
        }
    }
}

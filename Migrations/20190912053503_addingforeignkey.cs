using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class addingforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Category_CategoryID",
                table: "Stores");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryID",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Category_CategoryID",
                table: "Stores",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Category_CategoryID",
                table: "Stores");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryID",
                table: "Stores",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Category_CategoryID",
                table: "Stores",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

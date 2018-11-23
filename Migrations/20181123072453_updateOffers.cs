using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Products.Migrations
{
    public partial class updateOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreID",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StroreID",
                table: "Offers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Offers_StoreID",
                table: "Offers",
                column: "StoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Stores_StoreID",
                table: "Offers",
                column: "StoreID",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Stores_StoreID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_StoreID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "StroreID",
                table: "Offers");
        }
    }
}

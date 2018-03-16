using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlightSearch.Migrations
{
    public partial class FareResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fare_Result_ResultId",
                table: "Fare");

            migrationBuilder.DropIndex(
                name: "IX_Fare_ResultId",
                table: "Fare");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "Fare",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fare_ResultId",
                table: "Fare",
                column: "ResultId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fare_Result_ResultId",
                table: "Fare",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fare_Result_ResultId",
                table: "Fare");

            migrationBuilder.DropIndex(
                name: "IX_Fare_ResultId",
                table: "Fare");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "Fare",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Fare_ResultId",
                table: "Fare",
                column: "ResultId",
                unique: true,
                filter: "[ResultId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Fare_Result_ResultId",
                table: "Fare",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

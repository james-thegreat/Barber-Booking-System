using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBarberAvailabilitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberAvailabilitys_Barbers_BarberId",
                table: "BarberAvailabilitys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberAvailabilitys",
                table: "BarberAvailabilitys");

            migrationBuilder.RenameTable(
                name: "BarberAvailabilitys",
                newName: "BarberAvailabilities");

            migrationBuilder.RenameIndex(
                name: "IX_BarberAvailabilitys_BarberId",
                table: "BarberAvailabilities",
                newName: "IX_BarberAvailabilities_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberAvailabilities",
                table: "BarberAvailabilities",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BarberAvailabilities",
                columns: new[] { "Id", "BarberId", "DayOfWeek", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, 1, 2, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 3, 2, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 4, 2, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BarberAvailabilities_Barbers_BarberId",
                table: "BarberAvailabilities",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberAvailabilities_Barbers_BarberId",
                table: "BarberAvailabilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberAvailabilities",
                table: "BarberAvailabilities");

            migrationBuilder.DeleteData(
                table: "BarberAvailabilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BarberAvailabilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BarberAvailabilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BarberAvailabilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "BarberAvailabilities",
                newName: "BarberAvailabilitys");

            migrationBuilder.RenameIndex(
                name: "IX_BarberAvailabilities_BarberId",
                table: "BarberAvailabilitys",
                newName: "IX_BarberAvailabilitys_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberAvailabilitys",
                table: "BarberAvailabilitys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberAvailabilitys_Barbers_BarberId",
                table: "BarberAvailabilitys",
                column: "BarberId",
                principalTable: "Barbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

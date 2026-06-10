using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BarberBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedBarbersAndServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Bio", "DisplayName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Classic cuts and beard trims.", "James", true },
                    { 2, "Skin fades and modern styles.", "Mike", true }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "DurationMinutes", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Standard haircut", 30, true, "Haircut", 35m },
                    { 2, "Fresh skin fade", 45, true, "Skin Fade", 45m },
                    { 3, "Beard shaping and tidy up", 20, true, "Beard Trim", 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

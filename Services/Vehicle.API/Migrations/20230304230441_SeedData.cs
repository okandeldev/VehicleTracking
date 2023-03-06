using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "vehicle_statues",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { (short)1, "Connected" },
                    { (short)2, "Disconnected" }
                });

            migrationBuilder.InsertData(
                table: "vehicle",
                columns: new[] { "id", "created_by", "created_on", "customer_id", "customer_name", "deleted_on", "reg_nr", "updated_by", "updated_on", "vin", "vehicle_status_id" },
                values: new object[,]
                {
                    { new Guid("0c5bb5c0-516f-4c3f-8961-74171d433c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"), "Kalles Grustransporter AB", null, "GHI789", null, null, "VLUR4X20009048066", (short)2 },
                    { new Guid("469b6da0-d0f2-4f74-9598-a365fe965608"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b906b176-c75b-4a7d-92df-743f626d4fa1"), "Johans Bulk AB", null, "JKL012", null, null, "YS2R4X20005388011", (short)2 },
                    { new Guid("5c5057b0-90cf-4439-a30d-de6929c2faf3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"), "Kalles Grustransporter AB", null, "ABC123", null, null, "YS2R4X20005399401", (short)2 },
                    { new Guid("6a6d5811-5e19-4789-ad5f-c15065c0e359"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0055766-624e-44a8-b3f9-286429716226"), "Haralds Värdetransporter AB", null, "PQR678", null, null, "VLUR4X20009048066", (short)2 },
                    { new Guid("8c181bc6-56f5-4801-a37d-1ad6299a6576"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0055766-624e-44a8-b3f9-286429716226"), "Haralds Värdetransporter AB", null, "STU901", null, null, "YS2R4X20005387055", (short)2 },
                    { new Guid("8c7f4d32-8bd5-4914-ada2-56c393061e64"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"), "Kalles Grustransporter AB", null, "DEF456", null, null, "VLUR4X20009093588", (short)2 },
                    { new Guid("a39e1011-d40d-4b20-840e-4a4a10432694"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b906b176-c75b-4a7d-92df-743f626d4fa1"), "Johans Bulk AB", null, "MNO345", null, null, "YS2R4X20005387949", (short)2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("0c5bb5c0-516f-4c3f-8961-74171d433c0c"));

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("469b6da0-d0f2-4f74-9598-a365fe965608"));

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("5c5057b0-90cf-4439-a30d-de6929c2faf3"));

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("6a6d5811-5e19-4789-ad5f-c15065c0e359"));

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("8c181bc6-56f5-4801-a37d-1ad6299a6576"));

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("8c7f4d32-8bd5-4914-ada2-56c393061e64"));

            migrationBuilder.DeleteData(
                table: "vehicle",
                keyColumn: "id",
                keyValue: new Guid("a39e1011-d40d-4b20-840e-4a4a10432694"));

            migrationBuilder.DeleteData(
                table: "vehicle_statues",
                keyColumn: "id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "vehicle_statues",
                keyColumn: "id",
                keyValue: (short)2);
        }
    }
}

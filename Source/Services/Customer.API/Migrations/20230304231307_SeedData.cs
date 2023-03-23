using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "id", "address", "created_by", "created_on", "deleted_on", "full_name", "updated_by", "updated_on" },
                values: new object[,]
                {
                    { new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"), "Cementvägen 8, 111 11 Södertälje", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kalles Grustransporter AB", null, null },
                    { new Guid("b906b176-c75b-4a7d-92df-743f626d4fa1"), "Cementvägen 8, 111 11 Södertälje", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Johans Bulk AB", null, null },
                    { new Guid("d0055766-624e-44a8-b3f9-286429716226"), "Balkvägen 12, 222 22 Stockholm", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Haralds Värdetransporter AB", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "id",
                keyValue: new Guid("51c672c4-a292-4e5b-babd-6534a34e6853"));

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "id",
                keyValue: new Guid("b906b176-c75b-4a7d-92df-743f626d4fa1"));

            migrationBuilder.DeleteData(
                table: "customer",
                keyColumn: "id",
                keyValue: new Guid("d0055766-624e-44a8-b3f9-286429716226"));
        }
    }
}

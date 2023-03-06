using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VehicleAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "vehicle_statues",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle_statues", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    vin = table.Column<string>(type: "text", nullable: false),
                    regnr = table.Column<string>(name: "reg_nr", type: "text", nullable: false),
                    customerid = table.Column<Guid>(name: "customer_id", type: "uuid", nullable: false),
                    customername = table.Column<string>(name: "customer_name", type: "text", nullable: false),
                    vehiclestatusid = table.Column<short>(name: "vehicle_status_id", type: "smallint", nullable: false),
                    lastping = table.Column<DateTime>(name: "last_ping", type: "timestamp without time zone", nullable: true),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    createdon = table.Column<DateTime>(name: "created_on", type: "timestamp with time zone", nullable: false),
                    updatedby = table.Column<string>(name: "updated_by", type: "text", nullable: true),
                    updatedon = table.Column<DateTime>(name: "updated_on", type: "timestamp with time zone", nullable: true),
                    deletedon = table.Column<DateTime>(name: "deleted_on", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicle", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicle_vehicle_statues_vehicle_status_id",
                        column: x => x.vehiclestatusid,
                        principalTable: "vehicle_statues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicle_vehicle_status_id",
                table: "vehicle",
                column: "vehicle_status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "vehicle_statues");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAPI.Migrations
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
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    fullname = table.Column<string>(name: "full_name", type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: true),
                    createdon = table.Column<DateTime>(name: "created_on", type: "timestamp with time zone", nullable: false),
                    updatedby = table.Column<string>(name: "updated_by", type: "text", nullable: true),
                    updatedon = table.Column<DateTime>(name: "updated_on", type: "timestamp with time zone", nullable: true),
                    deletedon = table.Column<DateTime>(name: "deleted_on", type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}

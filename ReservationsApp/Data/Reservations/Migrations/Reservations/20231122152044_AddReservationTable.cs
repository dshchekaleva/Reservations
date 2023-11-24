using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReservationsApp.Migrations.Reservations
{
    /// <inheritdoc />
    public partial class AddReservationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ReservationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                ReservationLength = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Reservations", x => x.Id);
            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Reservations");
        }
    }
}

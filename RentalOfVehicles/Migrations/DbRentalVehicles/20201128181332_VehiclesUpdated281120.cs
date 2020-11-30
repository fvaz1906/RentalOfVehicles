using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalOfVehicles.Migrations.DbRentalVehicles
{
    public partial class VehiclesUpdated281120 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiclesReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DateReservationInitial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReservationFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclesReservation_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesReservation_VehiclesId",
                table: "VehiclesReservation",
                column: "VehiclesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiclesReservation");
        }
    }
}

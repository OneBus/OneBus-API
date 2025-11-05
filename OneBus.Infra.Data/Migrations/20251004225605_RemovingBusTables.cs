using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingBusTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusOperation");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.AddColumn<long>(
                name: "LineTimeId",
                table: "VehicleOperation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusChassisBrand",
                table: "Vehicle",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusChassisModel",
                table: "Vehicle",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "BusChassisYear",
                table: "Vehicle",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BusFumigateExpiration",
                table: "Vehicle",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BusHasLeftDoors",
                table: "Vehicle",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BusHasLowFloor",
                table: "Vehicle",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BusInsuranceExpiration",
                table: "Vehicle",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "BusServiceType",
                table: "Vehicle",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOperation_LineTimeId",
                table: "VehicleOperation",
                column: "LineTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOperation_LineTime_LineTimeId",
                table: "VehicleOperation",
                column: "LineTimeId",
                principalTable: "LineTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOperation_LineTime_LineTimeId",
                table: "VehicleOperation");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOperation_LineTimeId",
                table: "VehicleOperation");

            migrationBuilder.DropColumn(
                name: "LineTimeId",
                table: "VehicleOperation");

            migrationBuilder.DropColumn(
                name: "BusChassisBrand",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusChassisModel",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusChassisYear",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusFumigateExpiration",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusHasLeftDoors",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusHasLowFloor",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusInsuranceExpiration",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "BusServiceType",
                table: "Vehicle");

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    ChassisBrand = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ChassisModel = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ChassisYear = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FumigateExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    HasLeftDoors = table.Column<bool>(type: "boolean", nullable: false),
                    HasLowFloor = table.Column<bool>(type: "boolean", nullable: false),
                    InsuranceExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ServiceType = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bus_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusOperation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeWorkDayId = table.Column<long>(type: "bigint", nullable: false),
                    LineTimeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusOperation_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusOperation_EmployeeWorkday_EmployeeWorkDayId",
                        column: x => x.EmployeeWorkDayId,
                        principalTable: "EmployeeWorkday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusOperation_LineTime_LineTimeId",
                        column: x => x.LineTimeId,
                        principalTable: "LineTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_VehicleId",
                table: "Bus",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_BusOperation_BusId",
                table: "BusOperation",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusOperation_EmployeeWorkDayId",
                table: "BusOperation",
                column: "EmployeeWorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_BusOperation_LineTimeId",
                table: "BusOperation",
                column: "LineTimeId");
        }
    }
}

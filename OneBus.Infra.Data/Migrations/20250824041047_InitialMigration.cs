using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    Rg = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    BloodType = table.Column<byte>(type: "smallint", nullable: true),
                    Code = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    Role = table.Column<byte>(type: "smallint", nullable: false),
                    Email = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    HiringDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CnhNumber = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    CnhCategory = table.Column<byte>(type: "smallint", nullable: true),
                    CnhExpiration = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<byte>(type: "smallint", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    TravelTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Mileage = table.Column<decimal>(type: "numeric(19,4)", precision: 19, scale: 4, nullable: false),
                    MinNumberBuses = table.Column<byte>(type: "smallint", nullable: false),
                    MaxNumberBuses = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "character varying(80)", unicode: false, maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "character varying(32)", unicode: false, maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<byte>(type: "smallint", nullable: false),
                    Prefix = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    NumberDoors = table.Column<byte>(type: "smallint", nullable: false),
                    NumberSeats = table.Column<byte>(type: "smallint", nullable: false),
                    HasAccessibility = table.Column<bool>(type: "boolean", nullable: false),
                    FuelType = table.Column<byte>(type: "smallint", nullable: false),
                    Brand = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Plate = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    BodyworkNumber = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    NumberChassis = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    EngineNumber = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    AxesNumber = table.Column<byte>(type: "smallint", nullable: false),
                    IpvaExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    LicensingExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    Renavam = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: false),
                    TransmissionType = table.Column<byte>(type: "smallint", nullable: false),
                    AcquisitionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<byte>(type: "smallint", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkday",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    DayType = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkday_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineTime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LineId = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    DayType = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineTime_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceType = table.Column<byte>(type: "smallint", nullable: false),
                    ChassisBrand = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ChassisModel = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    ChassisYear = table.Column<int>(type: "integer", nullable: false),
                    HasLowFloor = table.Column<bool>(type: "boolean", nullable: false),
                    HasLeftDoors = table.Column<bool>(type: "boolean", nullable: false),
                    InsuranceExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    FumigateExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    Sector = table.Column<byte>(type: "smallint", nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SurveyExpiration = table.Column<DateOnly>(type: "date", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric(19,4)", precision: 19, scale: 4, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOperation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeWorkdayId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleOperation_EmployeeWorkday_EmployeeWorkdayId",
                        column: x => x.EmployeeWorkdayId,
                        principalTable: "EmployeeWorkday",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleOperation_Vehicle_VehicleId",
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
                    LineTimeId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeWorkDayId = table.Column<long>(type: "bigint", nullable: false),
                    BusId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "IsDeleted", "Name", "Password", "Salt" },
                values: new object[] { 1L, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Utc), "onebus@admin", false, "Administrador", "YRT66Z4XEJ2SSNaJVDIXQW7uvC8LSvOxDU1sH/Sr/ic=", "c37b6028194d489192aac9391801594a" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CnhNumber",
                table: "Employee",
                column: "CnhNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Code",
                table: "Employee",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Cpf",
                table: "Employee",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkday_EmployeeId",
                table: "EmployeeWorkday",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineTime_LineId",
                table: "LineTime",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_VehicleId",
                table: "Maintenance",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Plate",
                table: "Vehicle",
                column: "Plate");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Prefix",
                table: "Vehicle",
                column: "Prefix");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Renavam",
                table: "Vehicle",
                column: "Renavam");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOperation_EmployeeWorkdayId",
                table: "VehicleOperation",
                column: "EmployeeWorkdayId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOperation_VehicleId",
                table: "VehicleOperation",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusOperation");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VehicleOperation");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropTable(
                name: "LineTime");

            migrationBuilder.DropTable(
                name: "EmployeeWorkday");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}

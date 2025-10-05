using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVehicleFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicle");

            migrationBuilder.AddColumn<byte>(
                name: "Color",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "BusChassisBrand",
               table: "Vehicle");

            migrationBuilder.AddColumn<byte>(
                name: "BusChassisBrand",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "Brand",
               table: "Vehicle");

            migrationBuilder.AddColumn<byte>(
                name: "Brand",
                table: "Vehicle",
                nullable: false);           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Vehicle",
                type: "character varying(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusChassisBrand",
                table: "Vehicle",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Vehicle",
                type: "character varying(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");
        }
    }
}

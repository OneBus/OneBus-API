using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLineTableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxNumberBuses",
                table: "Line");

            migrationBuilder.RenameColumn(
                name: "MinNumberBuses",
                table: "Line",
                newName: "DirectionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DirectionType",
                table: "Line",
                newName: "MinNumberBuses");

            migrationBuilder.AddColumn<byte>(
                name: "MaxNumberBuses",
                table: "Line",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}

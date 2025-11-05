using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneBus.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDirectionTypeFromLineTimeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DirectionType",
                table: "LineTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DirectionType",
                table: "LineTime",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}

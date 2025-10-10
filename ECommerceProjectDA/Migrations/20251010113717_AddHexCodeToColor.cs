using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceProject.DA.Migrations
{
    /// <inheritdoc />
    public partial class AddHexCodeToColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HexCode",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HexCode",
                table: "Colors");
        }
    }
}

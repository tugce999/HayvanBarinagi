using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HayvanBarinagi.Migrations
{
    /// <inheritdoc />
    public partial class d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalTypeId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "GenderTypeId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OwnedTypeId",
                table: "Animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimalTypeId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GenderTypeId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnedTypeId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

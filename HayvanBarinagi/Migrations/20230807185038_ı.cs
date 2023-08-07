using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HayvanBarinagi.Migrations
{
    /// <inheritdoc />
    public partial class ı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalTypes",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OwnedType",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "sahip",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "sahip",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AnimalTypes",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnedType",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

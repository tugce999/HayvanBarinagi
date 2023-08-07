using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HayvanBarinagi.Migrations
{
    /// <inheritdoc />
    public partial class u : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalTypes_AnimalTypeId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_GenderType_GenderTypeId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_OwnedType_OwnedTypeId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "GenderType");

            migrationBuilder.DropTable(
                name: "OwnedType");

            migrationBuilder.DropIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_GenderTypeId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_OwnedTypeId",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "OwnedTypeId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GenderTypeId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AnimalTypeId",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AnimalTypes",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GenderType",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnedType",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalTypes",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "GenderType",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OwnedType",
                table: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "OwnedTypeId",
                table: "Animals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GenderTypeId",
                table: "Animals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalTypeId",
                table: "Animals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnedType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owned = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_GenderTypeId",
                table: "Animals",
                column: "GenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnedTypeId",
                table: "Animals",
                column: "OwnedTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalTypes_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId",
                principalTable: "AnimalTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_GenderType_GenderTypeId",
                table: "Animals",
                column: "GenderTypeId",
                principalTable: "GenderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_OwnedType_OwnedTypeId",
                table: "Animals",
                column: "OwnedTypeId",
                principalTable: "OwnedType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

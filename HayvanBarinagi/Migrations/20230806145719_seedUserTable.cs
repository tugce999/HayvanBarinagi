using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HayvanBarinagi.Migrations
{
    /// <inheritdoc />
    public partial class seedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "OwnedType");

            migrationBuilder.DropTable(
                name: "Cins");

            migrationBuilder.DropTable(
                name: "Tür");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAdd", "NameSurname", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 6, 17, 57, 19, 148, DateTimeKind.Local).AddTicks(9013), "Tuğçe", "123", "user", "tugce" },
                    { 10, new DateTime(2023, 8, 6, 17, 57, 19, 148, DateTimeKind.Local).AddTicks(9027), "Tuğçe2", "345", "user", "tugce2" },
                    { 11, new DateTime(2023, 8, 6, 17, 57, 19, 148, DateTimeKind.Local).AddTicks(9025), "2112@sakarya.edu.tr", "saü", "admin", "2112@sakarya.edu.tr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.CreateTable(
                name: "Cins",
                columns: table => new
                {
                    CinsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cins", x => x.CinsId);
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

            migrationBuilder.CreateTable(
                name: "Tür",
                columns: table => new
                {
                    TurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tür", x => x.TurId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    HayvanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsId = table.Column<int>(type: "int", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    EkBilgiler = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SahiplenildiMi = table.Column<bool>(type: "bit", nullable: false),
                    Yasi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.HayvanId);
                    table.ForeignKey(
                        name: "FK_Animals_Cins_CinsId",
                        column: x => x.CinsId,
                        principalTable: "Cins",
                        principalColumn: "CinsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Tür_TurId",
                        column: x => x.TurId,
                        principalTable: "Tür",
                        principalColumn: "TurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CinsId",
                table: "Animals",
                column: "CinsId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_TurId",
                table: "Animals",
                column: "TurId");
        }
    }
}

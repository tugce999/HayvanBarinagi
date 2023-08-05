using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HayvanBarinagi.Migrations
{
    /// <inheritdoc />
    public partial class animalscreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Animals",
               columns: table => new
               {
                   HayvanId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Adı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                   CinsId = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                   Cinsiyet = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                   EkBilgiler = table.Column<string>(type: "nvarchar(50)", nullable: false),
                   Foto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                   SahiplenildiMi = table.Column<bool>(type: "bit", nullable: false),
                   TurId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                   Yasi = table.Column<int>(type: "int", maxLength: 50, nullable: false)
               });
             
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}

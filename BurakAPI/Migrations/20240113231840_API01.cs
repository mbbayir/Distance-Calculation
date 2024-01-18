using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurakAPI.Migrations
{
    /// <inheritdoc />
    public partial class API01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarifeHesaplayiciModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslangicAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VarisAdres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesafe = table.Column<double>(type: "float", nullable: true),
                    HataMesaji = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarifeHesaplayiciModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarifeHesaplayiciModels");
        }
    }
}

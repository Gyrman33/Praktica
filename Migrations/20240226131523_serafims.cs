using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp2.Migrations
{
    /// <inheritdoc />
    public partial class serafims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<int>(type: "int", nullable: false),
                    TovaraIdi = table.Column<int>(type: "int", nullable: false),
                    Nazv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolvo = table.Column<int>(type: "int", nullable: false),
                    Stoimost = table.Column<int>(type: "int", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korzs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tovars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolvo = table.Column<int>(type: "int", nullable: false),
                    Stoimost = table.Column<int>(type: "int", nullable: false),
                    Pic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tovars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korzs");

            migrationBuilder.DropTable(
                name: "Tovars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

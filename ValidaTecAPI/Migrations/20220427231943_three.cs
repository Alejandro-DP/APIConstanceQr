using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidaTecAPI.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carrers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UI_Carrer_User",
                table: "Users",
                column: "CarrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrers_UserId",
                table: "Carrers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrers");

            migrationBuilder.DropIndex(
                name: "UI_Carrer_User",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CarrerId",
                table: "Users");
        }
    }
}

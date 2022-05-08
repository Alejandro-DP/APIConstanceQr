using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidaTecAPI.Migrations
{
    public partial class twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrers_Users_UserId",
                table: "Carrers");

            migrationBuilder.DropIndex(
                name: "IX_Carrers_UserId",
                table: "Carrers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carrers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Carrers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carrers_UserId",
                table: "Carrers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrers_Users_UserId",
                table: "Carrers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValidaTecAPI.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarrerId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Folio",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Carrers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IU_Carrer_Course",
                table: "Courses",
                column: "CarrerId");

            migrationBuilder.CreateIndex(
                name: "IX_Carrers_CoursesId",
                table: "Carrers",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrers_Courses_CoursesId",
                table: "Carrers",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrers_Courses_CoursesId",
                table: "Carrers");

            migrationBuilder.DropIndex(
                name: "IU_Carrer_Course",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Carrers_CoursesId",
                table: "Carrers");

            migrationBuilder.DropColumn(
                name: "CarrerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Folio",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Carrers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMentorApp.Api.Migrations
{
    public partial class gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Mentors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Mentors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Mentors",
                keyColumn: "MentorsId",
                keyValue: 2,
                column: "Gender",
                value: 1);
        }
    }
}

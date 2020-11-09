using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMentorApp.Api.Migrations
{
    public partial class withoutqualificatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mentors_Qualification_QualificationId",
                table: "mentors");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mentors",
                table: "mentors");

            migrationBuilder.DropIndex(
                name: "IX_mentors_QualificationId",
                table: "mentors");

            migrationBuilder.DropColumn(
                name: "QualificationId",
                table: "mentors");

            migrationBuilder.RenameTable(
                name: "mentors",
                newName: "Mentors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors",
                column: "MentorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentors",
                table: "Mentors");

            migrationBuilder.RenameTable(
                name: "Mentors",
                newName: "mentors");

            migrationBuilder.AddColumn<int>(
                name: "QualificationId",
                table: "mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_mentors",
                table: "mentors",
                column: "MentorsId");

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mentors_QualificationId",
                table: "mentors",
                column: "QualificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_mentors_Qualification_QualificationId",
                table: "mentors",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "QualificationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

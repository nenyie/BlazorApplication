using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMentorApp.Api.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationId);
                });

            migrationBuilder.CreateTable(
                name: "mentors",
                columns: table => new
                {
                    MentorsId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    QualificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mentors", x => x.MentorsId);
                    table.ForeignKey(
                        name: "FK_mentors_Qualification_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "QualificationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "mentors",
                columns: new[] { "MentorsId", "Email", "FirstName", "Gender", "LastName", "PhotoPath", "QualificationId", "Username" },
                values: new object[] { 1, "johnWick@gmail.com", "john", 0, "wick", "images/car2.jpeg", null, "JW" });

            migrationBuilder.InsertData(
                table: "mentors",
                columns: new[] { "MentorsId", "Email", "FirstName", "Gender", "LastName", "PhotoPath", "QualificationId", "Username" },
                values: new object[] { 2, "janeWick@gmail.com", "jane", 1, "wick", "images/car3.jpeg", null, "JW" });

            migrationBuilder.CreateIndex(
                name: "IX_mentors_QualificationId",
                table: "mentors",
                column: "QualificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mentors");

            migrationBuilder.DropTable(
                name: "Qualification");
        }
    }
}

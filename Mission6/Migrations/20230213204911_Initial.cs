using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.ApplicationID);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action, Adventure, Drama", "Peter Jackson", false, "Nobody", "Great movie!", "PG-13", "The Lord of the Rings: The Fellowship of the Ring", "2001" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Action, Adventure, Drama", "Peter Jackson", false, "Nobody", "Has some great action scenes!", "PG-13", "The Lord of the Rings: The Two Towers", "2002" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Action, Adventure, Drama", "Peter Jackson", false, "Nobody", "Words cannot describe how great this movie is!", "PG-13", "The Lord of the Rings: The Return of the Ring", "2003" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_responses_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Action, Adventure, Drama" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Fantasy" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Peter Jackson", false, "Nobody", "Great movie!", "PG-13", "The Lord of the Rings: The Fellowship of the Ring", "2001" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Peter Jackson", false, "Nobody", "Has some great action scenes!", "PG-13", "The Lord of the Rings: The Two Towers", "2002" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "ApplicationID", "CategoryID", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 1, "Peter Jackson", false, "Nobody", "Words cannot describe how great this movie is!", "PG-13", "The Lord of the Rings: The Return of the Ring", "2003" });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryID",
                table: "responses",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}

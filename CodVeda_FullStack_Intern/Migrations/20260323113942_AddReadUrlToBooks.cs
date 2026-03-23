using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodVeda_FullStack_Intern.Migrations
{
    /// <inheritdoc />
    public partial class AddReadUrlToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReadUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "Publisher", "ReadUrl", "Summary", "Title" },
                values: new object[] { "1892", "George Newnes", "https://www.gutenberg.org/files/1661/1661-h/1661-h.htm", "A collection of twelve short stories featuring the legendary detective Sherlock Holmes and his companion Dr. Watson.", "The Adventures of Sherlock Holmes" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishDate", "Publisher", "ReadUrl", "Summary", "Title" },
                values: new object[] { "1865", "Macmillan", "https://www.gutenberg.org/files/11/11-h/11-h.htm", "A young girl named Alice falls through a rabbit hole into a fantasy world populated by peculiar, anthropomorphic creatures.", "Alice's Adventures in Wonderland" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublishDate", "Publisher", "ReadUrl", "Summary", "Title" },
                values: new object[] { "1925", "Charles Scribner's Sons", "https://www.gutenberg.org/cache/epub/64317/pg64317-images.html", "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan in the Roaring Twenties.", "The Great Gatsby" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadUrl",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PublishDate", "Publisher", "Summary", "Title" },
                values: new object[] { "2024", "CodVeda Press", "The comprehensive history of how the BookFlow library management system was developed during the internship.", "BookFlow History" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PublishDate", "Publisher", "Summary", "Title" },
                values: new object[] { "2023", "University Press", "Exploring the digital transformation of student connections and resource sharing in academic environments.", "UfsConnectBook History" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PublishDate", "Publisher", "Summary", "Title" },
                values: new object[] { "2025", "Tech Pioneers Publishing", "A deep dive into the journey of Lindele Nyambe, focusing on software engineering milestones and future visions.", "Lindele's History" });
        }
    }
}

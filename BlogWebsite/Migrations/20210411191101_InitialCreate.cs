using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebsite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Given_Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Last_Name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    emailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    WebsiteAddress = table.Column<string>(type: "TEXT", nullable: true),
                    TelephoneNum = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    province = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorModelId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogModelId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    AuthorModel = table.Column<Guid>(type: "TEXT", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogModelId);
                    table.ForeignKey(
                        name: "FK_Blogs_Authors_AuthorModel",
                        column: x => x.AuthorModel,
                        principalTable: "Authors",
                        principalColumn: "AuthorModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorModel",
                table: "Blogs",
                column: "AuthorModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

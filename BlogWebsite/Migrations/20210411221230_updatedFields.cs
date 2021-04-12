using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebsite.Migrations
{
    public partial class updatedFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Authors_AuthorModel",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AuthorModel",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorModelId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "AuthorModel",
                table: "Blogs",
                newName: "AuthorName");

            migrationBuilder.AddColumn<string>(
                name: "AuthorEmailID",
                table: "Blogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "emailAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorEmailID",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Blogs",
                newName: "AuthorModel");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorModelId",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "AuthorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorModel",
                table: "Blogs",
                column: "AuthorModel");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Authors_AuthorModel",
                table: "Blogs",
                column: "AuthorModel",
                principalTable: "Authors",
                principalColumn: "AuthorModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksInventory.Migrations
{
    public partial class BookTypesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(500)", nullable: false),
                    Author = table.Column<string>(type: "varchar(500)", nullable: false),
                    covertype = table.Column<string>(type: "varchar(500)", nullable: false),
                    ISBN = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    coverimage = table.Column<string>(type: "varchar(500)", nullable: false),
                    unitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTypes");
        }
    }
}

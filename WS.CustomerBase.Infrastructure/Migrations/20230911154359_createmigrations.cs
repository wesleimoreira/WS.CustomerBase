using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WS.CustomerBase.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 11, 12, 43, 59, 284, DateTimeKind.Local).AddTicks(6289)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 9, 11, 12, 43, 59, 284, DateTimeKind.Local).AddTicks(6689))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fruity.Migrations
{
    public partial class review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RMessage = table.Column<string>(type: "nvarchar(max)",  nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

         
        }
    }
}

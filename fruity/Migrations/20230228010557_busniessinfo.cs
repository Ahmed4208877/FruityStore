using Microsoft.EntityFrameworkCore.Migrations;

namespace fruity.Migrations
{
    public partial class busniessinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbBusniessInfos",
                columns: table => new
                {
                    BusniessInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusniesssCardNum = table.Column<int>(type: "int", nullable: false),
                    officePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBusniessInfos", x => x.BusniessInfoId);
                    table.ForeignKey(
                        name: "FK_TbBusniessInfos_TbCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "TbCustomers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbBusniessInfos_CustomerId",
                table: "TbBusniessInfos",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbBusniessInfos");
        }
    }
}

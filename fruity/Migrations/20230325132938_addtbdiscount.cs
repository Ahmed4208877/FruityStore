using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace fruity.Migrations
{
    public partial class addtbdiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbItemDiscounts",
                columns: table => new
                {
                    ItemDiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    DiscountPresent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbItemDiscounts", x => x.ItemDiscountId);
                    table.ForeignKey(
                        name: "FK_TbItemDiscounts_TbItems",
                        column: x => x.ItemId,
                        principalTable: "TbItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

      

            migrationBuilder.CreateIndex(
                name: "IX_TbItemDiscounts_ItemId",
                table: "TbItemDiscounts",
                column: "ItemId");

       
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
       
            migrationBuilder.DropTable(
                name: "TbItemDiscounts");

          
        }
    }
}

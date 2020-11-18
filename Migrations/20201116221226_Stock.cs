using Microsoft.EntityFrameworkCore.Migrations;

namespace InitCMS.Migrations
{
    public partial class Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Product_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");
        }
    }
}

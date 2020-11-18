using Microsoft.EntityFrameworkCore.Migrations;

namespace InitCMS.Migrations
{
    public partial class UpdateReceiptSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sales_ReceiptId",
                table: "Sales",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Receipts_ReceiptId",
                table: "Sales",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Receipts_ReceiptId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ReceiptId",
                table: "Sales");
        }
    }
}

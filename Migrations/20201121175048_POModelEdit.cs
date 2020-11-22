using Microsoft.EntityFrameworkCore.Migrations;

namespace InitCMS.Migrations
{
    public partial class POModelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_POStatuses_POStatusId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PurchaseOrder");

            migrationBuilder.AlterColumn<int>(
                name: "POStatusId",
                table: "PurchaseOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_POStatuses_POStatusId",
                table: "PurchaseOrder",
                column: "POStatusId",
                principalTable: "POStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_POStatuses_POStatusId",
                table: "PurchaseOrder");

            migrationBuilder.AlterColumn<int>(
                name: "POStatusId",
                table: "PurchaseOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PurchaseOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_POStatuses_POStatusId",
                table: "PurchaseOrder",
                column: "POStatusId",
                principalTable: "POStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

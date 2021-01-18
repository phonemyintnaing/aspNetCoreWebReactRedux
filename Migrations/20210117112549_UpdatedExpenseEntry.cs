using Microsoft.EntityFrameworkCore.Migrations;

namespace InitCMS.Migrations
{
    public partial class UpdatedExpenseEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntry_Coa_CoaId1",
                table: "ExpenseEntry");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseEntry_CoaId1",
                table: "ExpenseEntry");

            migrationBuilder.DropColumn(
                name: "CoaId1",
                table: "ExpenseEntry");

            migrationBuilder.AlterColumn<int>(
                name: "CoaId",
                table: "ExpenseEntry",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseEntry_CoaId",
                table: "ExpenseEntry",
                column: "CoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntry_Coa_CoaId",
                table: "ExpenseEntry",
                column: "CoaId",
                principalTable: "Coa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseEntry_Coa_CoaId",
                table: "ExpenseEntry");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseEntry_CoaId",
                table: "ExpenseEntry");

            migrationBuilder.AlterColumn<string>(
                name: "CoaId",
                table: "ExpenseEntry",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CoaId1",
                table: "ExpenseEntry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseEntry_CoaId1",
                table: "ExpenseEntry",
                column: "CoaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseEntry_Coa_CoaId1",
                table: "ExpenseEntry",
                column: "CoaId1",
                principalTable: "Coa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

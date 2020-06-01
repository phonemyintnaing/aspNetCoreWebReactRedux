using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcRoom.Migrations
{
    public partial class CreateProductListAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategoryList",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Org_InStock = table.Column<int>(nullable: false),
                    Update_InStock = table.Column<int>(nullable: false),
                    ProductListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryList", x => x.CatId);
                    table.ForeignKey(
                        name: "FK_ProductCategoryList_ProductList_ProductListId",
                        column: x => x.ProductListId,
                        principalTable: "ProductList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryList_ProductListId",
                table: "ProductCategoryList",
                column: "ProductListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategoryList");
        }
    }
}

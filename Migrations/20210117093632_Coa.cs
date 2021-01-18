using Microsoft.EntityFrameworkCore.Migrations;

namespace InitCMS.Migrations
{
    public partial class Coa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoaType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(maxLength: 3, nullable: true),
                    Description = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(maxLength: 16, nullable: true),
                    Description = table.Column<string>(maxLength: 30, nullable: true),
                    CoaTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coa_CoaType_CoaTypeId",
                        column: x => x.CoaTypeId,
                        principalTable: "CoaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coa_CoaTypeId",
                table: "Coa",
                column: "CoaTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coa");

            migrationBuilder.DropTable(
                name: "CoaType");
        }
    }
}

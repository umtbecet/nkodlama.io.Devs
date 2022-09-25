using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "ProductId" },
                values: new object[] { 1, "", "Java Junior", 1500m, 1 });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "ProductId" },
                values: new object[] { 2, "", "Java Senior", 5500m, 2 });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "ImageUrl", "Name", "Price", "ProductId" },
                values: new object[] { 3, "", "C# Junior", 2500m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Models_ProductId",
                table: "Models",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");
        }
    }
}

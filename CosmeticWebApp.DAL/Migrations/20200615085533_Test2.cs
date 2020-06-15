using Microsoft.EntityFrameworkCore.Migrations;

namespace CosmeticWebApp.DAL.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Amounts = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => new { x.Account, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Cart_Personal_Information_Account",
                        column: x => x.Account,
                        principalTable: "Personal_Information",
                        principalColumn: "Account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}

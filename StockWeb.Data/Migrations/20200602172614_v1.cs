using Microsoft.EntityFrameworkCore.Migrations;

namespace StockWeb.Data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AspNetUsers_UserId1",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_AspNetUsers_UserId1",
                table: "Sellings");

            migrationBuilder.DropIndex(
                name: "IX_Sellings_UserId1",
                table: "Sellings");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId1",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Sellings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Purchases");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sellings",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_UserId",
                table: "Sellings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesId",
                table: "Products",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriesId",
                table: "Products",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AspNetUsers_UserId",
                table: "Purchases",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_AspNetUsers_UserId",
                table: "Sellings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriesId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AspNetUsers_UserId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_AspNetUsers_UserId",
                table: "Sellings");

            migrationBuilder.DropIndex(
                name: "IX_Sellings_UserId",
                table: "Sellings");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Sellings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Sellings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Purchases",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Purchases",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_UserId1",
                table: "Sellings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId1",
                table: "Purchases",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AspNetUsers_UserId1",
                table: "Purchases",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_AspNetUsers_UserId1",
                table: "Sellings",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

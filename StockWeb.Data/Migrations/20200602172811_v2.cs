using Microsoft.EntityFrameworkCore.Migrations;

namespace StockWeb.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sellings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Sellings",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Purchases",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_UsersId",
                table: "Sellings",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UsersId",
                table: "Purchases",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_AspNetUsers_UsersId",
                table: "Purchases",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellings_AspNetUsers_UsersId",
                table: "Sellings",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_AspNetUsers_UsersId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellings_AspNetUsers_UsersId",
                table: "Sellings");

            migrationBuilder.DropIndex(
                name: "IX_Sellings_UsersId",
                table: "Sellings");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_UsersId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Sellings");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Purchases");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sellings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Purchases",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sellings_UserId",
                table: "Sellings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                column: "UserId");

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
    }
}

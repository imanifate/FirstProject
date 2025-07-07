using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class tbl6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSubGroups_ProductSubGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSubGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSubGroupId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubGroupId",
                table: "Products",
                column: "SubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_GroupId",
                table: "Products",
                column: "GroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSubGroups_SubGroupId",
                table: "Products",
                column: "SubGroupId",
                principalTable: "ProductSubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_GroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSubGroups_SubGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubGroupId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductSubGroupId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSubGroupId",
                table: "Products",
                column: "ProductSubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSubGroups_ProductSubGroupId",
                table: "Products",
                column: "ProductSubGroupId",
                principalTable: "ProductSubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

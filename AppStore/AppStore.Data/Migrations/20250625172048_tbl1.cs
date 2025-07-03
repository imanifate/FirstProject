using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class tbl1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductGroups_ProductGroupId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSubGroups_ProductSubGroupId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGallery_Product_ProductId",
                table: "ProductGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGallery",
                table: "ProductGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductGallery",
                newName: "ProductGalleries");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGallery_ProductId",
                table: "ProductGalleries",
                newName: "IX_ProductGalleries_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductSubGroupId",
                table: "Products",
                newName: "IX_Products_ProductSubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductGroupId",
                table: "Products",
                newName: "IX_Products_ProductGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGalleries",
                table: "ProductGalleries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGalleries_Products_ProductId",
                table: "ProductGalleries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGalleries_Products_ProductId",
                table: "ProductGalleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSubGroups_ProductSubGroupId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGalleries",
                table: "ProductGalleries");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductGalleries",
                newName: "ProductGallery");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductSubGroupId",
                table: "Product",
                newName: "IX_Product_ProductSubGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductGroupId",
                table: "Product",
                newName: "IX_Product_ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGalleries_ProductId",
                table: "ProductGallery",
                newName: "IX_ProductGallery_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGallery",
                table: "ProductGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Product_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductGroups_ProductGroupId",
                table: "Product",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSubGroups_ProductSubGroupId",
                table: "Product",
                column: "ProductSubGroupId",
                principalTable: "ProductSubGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGallery_Product_ProductId",
                table: "ProductGallery",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

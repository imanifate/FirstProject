using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class tbletabl2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductSubGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductSubGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Accounts");
        }
    }
}

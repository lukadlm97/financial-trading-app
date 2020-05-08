using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTrader.EntityFramework.Migrations
{
    public partial class stocktoassets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock_Syimbol",
                table: "AssetTransaction");

            migrationBuilder.RenameColumn(
                name: "Stock_PricePerShare",
                table: "AssetTransaction",
                newName: "Asset_PricePerShare");

            migrationBuilder.AddColumn<string>(
                name: "Asset_Symbol",
                table: "AssetTransaction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asset_Symbol",
                table: "AssetTransaction");

            migrationBuilder.RenameColumn(
                name: "Asset_PricePerShare",
                table: "AssetTransaction",
                newName: "Stock_PricePerShare");

            migrationBuilder.AddColumn<string>(
                name: "Stock_Syimbol",
                table: "AssetTransaction",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

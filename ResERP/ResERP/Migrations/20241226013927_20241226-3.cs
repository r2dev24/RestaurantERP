using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResERP.Migrations
{
    /// <inheritdoc />
    public partial class _202412263 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "BranchAdress",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "BranchAdress");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

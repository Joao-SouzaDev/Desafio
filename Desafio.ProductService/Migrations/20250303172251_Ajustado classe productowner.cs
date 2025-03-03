using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightLoop.ProductService.Migrations
{
    /// <inheritdoc />
    public partial class Ajustadoclasseproductowner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProductOwners",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ProductOwners",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

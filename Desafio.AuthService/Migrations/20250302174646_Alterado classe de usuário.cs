using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightLoop.Auth.Migrations
{
    /// <inheritdoc />
    public partial class Alteradoclassedeusuário : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Users",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Users",
                newName: "Document");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAddOns5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UsersColis",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "UsersColis");
        }
    }
}

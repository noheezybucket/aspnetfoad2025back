using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAddOns2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prénoom",
                table: "UsersColis",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "UsersColis",
                newName: "Adresse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "UsersColis",
                newName: "Prénoom");

            migrationBuilder.RenameColumn(
                name: "Adresse",
                table: "UsersColis",
                newName: "Adress");
        }
    }
}

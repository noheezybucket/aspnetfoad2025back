using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class AddLivreur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarteGris",
                table: "UsersColis",
                type: "character varying(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UsersColis",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "UsersColis",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Premis",
                table: "UsersColis",
                type: "character varying(25)",
                maxLength: 25,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarteGris",
                table: "UsersColis");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UsersColis");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "UsersColis");

            migrationBuilder.DropColumn(
                name: "Premis",
                table: "UsersColis");
        }
    }
}

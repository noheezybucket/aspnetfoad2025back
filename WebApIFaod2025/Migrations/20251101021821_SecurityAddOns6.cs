using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAddOns6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colis_UsersColis_ClientId",
                table: "Colis");

            migrationBuilder.DropIndex(
                name: "IX_Colis_ClientId",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "DescriptionColis",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "LibelleColis",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "PoidsColis",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "TypeColis",
                table: "Colis");

            migrationBuilder.AlterColumn<string>(
                name: "CodeColis",
                table: "Colis",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "AdresseArrivee",
                table: "Colis",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdresseDepart",
                table: "Colis",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Colis",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Colis",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "Colis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Poids",
                table: "Colis",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Livraisons",
                columns: table => new
                {
                    IdLivraison = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdColis = table.Column<int>(type: "integer", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Statut = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livraisons", x => x.IdLivraison);
                    table.ForeignKey(
                        name: "FK_Livraisons_Colis_IdColis",
                        column: x => x.IdColis,
                        principalTable: "Colis",
                        principalColumn: "IdColis",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colis_IdClient",
                table: "Colis",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_IdColis",
                table: "Livraisons",
                column: "IdColis",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Colis_UsersColis_IdClient",
                table: "Colis",
                column: "IdClient",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colis_UsersColis_IdClient",
                table: "Colis");

            migrationBuilder.DropTable(
                name: "Livraisons");

            migrationBuilder.DropIndex(
                name: "IX_Colis_IdClient",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "AdresseArrivee",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "AdresseDepart",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "Poids",
                table: "Colis");

            migrationBuilder.AlterColumn<string>(
                name: "CodeColis",
                table: "Colis",
                type: "character varying(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Colis",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionColis",
                table: "Colis",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LibelleColis",
                table: "Colis",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "PoidsColis",
                table: "Colis",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TypeColis",
                table: "Colis",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Colis_ClientId",
                table: "Colis",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colis_UsersColis_ClientId",
                table: "Colis",
                column: "ClientId",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis");
        }
    }
}

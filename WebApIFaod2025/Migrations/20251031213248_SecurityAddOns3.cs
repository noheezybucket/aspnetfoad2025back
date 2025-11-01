using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAddOns3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "libelleColis",
                table: "Colis",
                newName: "LibelleColis");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Colis",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LivreurId",
                table: "Colis",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DemandeColis",
                columns: table => new
                {
                    IdDemande = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    AdresseEnlevement = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    AdresseLivraison = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    PoidsEstime = table.Column<float>(type: "real", nullable: false),
                    TypeColis = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DateDemande = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Statut = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandeColis", x => x.IdDemande);
                    table.ForeignKey(
                        name: "FK_DemandeColis_UsersColis_ClientId",
                        column: x => x.ClientId,
                        principalTable: "UsersColis",
                        principalColumn: "IdUsersColis",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuiviCommande",
                columns: table => new
                {
                    IdSuivi = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColisId = table.Column<int>(type: "integer", nullable: false),
                    Statut = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DateMiseAJour = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PositionGPS = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Commentaire = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiviCommande", x => x.IdSuivi);
                    table.ForeignKey(
                        name: "FK_SuiviCommande_Colis_ColisId",
                        column: x => x.ColisId,
                        principalTable: "Colis",
                        principalColumn: "IdColis",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colis_ClientId",
                table: "Colis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Colis_LivreurId",
                table: "Colis",
                column: "LivreurId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandeColis_ClientId",
                table: "DemandeColis",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SuiviCommande_ColisId",
                table: "SuiviCommande",
                column: "ColisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colis_UsersColis_ClientId",
                table: "Colis",
                column: "ClientId",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis");

            migrationBuilder.AddForeignKey(
                name: "FK_Colis_UsersColis_LivreurId",
                table: "Colis",
                column: "LivreurId",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colis_UsersColis_ClientId",
                table: "Colis");

            migrationBuilder.DropForeignKey(
                name: "FK_Colis_UsersColis_LivreurId",
                table: "Colis");

            migrationBuilder.DropTable(
                name: "DemandeColis");

            migrationBuilder.DropTable(
                name: "SuiviCommande");

            migrationBuilder.DropIndex(
                name: "IX_Colis_ClientId",
                table: "Colis");

            migrationBuilder.DropIndex(
                name: "IX_Colis_LivreurId",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "LivreurId",
                table: "Colis");

            migrationBuilder.RenameColumn(
                name: "LibelleColis",
                table: "Colis",
                newName: "libelleColis");
        }
    }
}

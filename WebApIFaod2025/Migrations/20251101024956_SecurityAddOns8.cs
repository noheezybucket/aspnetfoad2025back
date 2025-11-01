using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class SecurityAddOns8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colis_UsersColis_IdClient",
                table: "Colis");

            migrationBuilder.DropForeignKey(
                name: "FK_Colis_UsersColis_LivreurId",
                table: "Colis");

            migrationBuilder.DropIndex(
                name: "IX_Colis_IdClient",
                table: "Colis");

            migrationBuilder.DropIndex(
                name: "IX_Colis_LivreurId",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "LivreurId",
                table: "Colis");

            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "Livraisons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLivreur",
                table: "Livraisons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Colis",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CodeColis",
                table: "Colis",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AdresseDepart",
                table: "Colis",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "AdresseArrivee",
                table: "Colis",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "StatutLivraison",
                table: "Colis",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_IdClient",
                table: "Livraisons",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_IdLivreur",
                table: "Livraisons",
                column: "IdLivreur");

            migrationBuilder.AddForeignKey(
                name: "FK_Livraisons_UsersColis_IdClient",
                table: "Livraisons",
                column: "IdClient",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Livraisons_UsersColis_IdLivreur",
                table: "Livraisons",
                column: "IdLivreur",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livraisons_UsersColis_IdClient",
                table: "Livraisons");

            migrationBuilder.DropForeignKey(
                name: "FK_Livraisons_UsersColis_IdLivreur",
                table: "Livraisons");

            migrationBuilder.DropIndex(
                name: "IX_Livraisons_IdClient",
                table: "Livraisons");

            migrationBuilder.DropIndex(
                name: "IX_Livraisons_IdLivreur",
                table: "Livraisons");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Livraisons");

            migrationBuilder.DropColumn(
                name: "IdLivreur",
                table: "Livraisons");

            migrationBuilder.DropColumn(
                name: "StatutLivraison",
                table: "Colis");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Colis",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CodeColis",
                table: "Colis",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "AdresseDepart",
                table: "Colis",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "AdresseArrivee",
                table: "Colis",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "Colis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LivreurId",
                table: "Colis",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colis_IdClient",
                table: "Colis",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Colis_LivreurId",
                table: "Colis",
                column: "LivreurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colis_UsersColis_IdClient",
                table: "Colis",
                column: "IdClient",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Colis_UsersColis_LivreurId",
                table: "Colis",
                column: "LivreurId",
                principalTable: "UsersColis",
                principalColumn: "IdUsersColis");
        }
    }
}

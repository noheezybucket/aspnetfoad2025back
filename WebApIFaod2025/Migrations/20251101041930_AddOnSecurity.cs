using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class AddOnSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClient",
                table: "Colis",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colis_IdClient",
                table: "Colis",
                column: "IdClient");

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

            migrationBuilder.DropIndex(
                name: "IX_Colis_IdClient",
                table: "Colis");

            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "Colis");
        }
    }
}

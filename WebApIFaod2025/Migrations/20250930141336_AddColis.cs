using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApIFaod2025.Migrations
{
    /// <inheritdoc />
    public partial class AddColis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colis",
                columns: table => new
                {
                    IdColis = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeColis = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    libelleColis = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    DescriptionColis = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PoidsColis = table.Column<float>(type: "real", nullable: false),
                    TypeColis = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colis", x => x.IdColis);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colis");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fussball.Migrations
{
    /// <inheritdoc />
    public partial class fkKampspiller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kampspiller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KampId = table.Column<int>(type: "int", nullable: false),
                    spillerId = table.Column<int>(type: "int", nullable: false),
                    Lag1 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kampspiller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kampspiller_Kamp_KampId",
                        column: x => x.KampId,
                        principalTable: "Kamp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kampspiller_KampId",
                table: "Kampspiller",
                column: "KampId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kampspiller");
        }
    }
}

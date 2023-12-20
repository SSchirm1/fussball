using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fussball.Migrations
{
    /// <inheritdoc />
    public partial class kampspillertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spiller_Kamp_KampId",
                table: "Spiller");

            migrationBuilder.DropForeignKey(
                name: "FK_Spiller_Kamp_KampId1",
                table: "Spiller");

            migrationBuilder.DropIndex(
                name: "IX_Spiller_KampId",
                table: "Spiller");

            migrationBuilder.DropIndex(
                name: "IX_Spiller_KampId1",
                table: "Spiller");

            migrationBuilder.DropColumn(
                name: "KampId",
                table: "Spiller");

            migrationBuilder.DropColumn(
                name: "KampId1",
                table: "Spiller");

            migrationBuilder.AddColumn<int>(
                name: "ScoreLag1",
                table: "Kamp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreLag2",
                table: "Kamp",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreLag1",
                table: "Kamp");

            migrationBuilder.DropColumn(
                name: "ScoreLag2",
                table: "Kamp");

            migrationBuilder.AddColumn<int>(
                name: "KampId",
                table: "Spiller",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KampId1",
                table: "Spiller",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spiller_KampId",
                table: "Spiller",
                column: "KampId");

            migrationBuilder.CreateIndex(
                name: "IX_Spiller_KampId1",
                table: "Spiller",
                column: "KampId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Spiller_Kamp_KampId",
                table: "Spiller",
                column: "KampId",
                principalTable: "Kamp",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Spiller_Kamp_KampId1",
                table: "Spiller",
                column: "KampId1",
                principalTable: "Kamp",
                principalColumn: "Id");
        }
    }
}

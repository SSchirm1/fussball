using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fussball.Migrations
{
    /// <inheritdoc />
    public partial class addedkamperclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Kamp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dato = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kamp", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spiller_Kamp_KampId",
                table: "Spiller");

            migrationBuilder.DropForeignKey(
                name: "FK_Spiller_Kamp_KampId1",
                table: "Spiller");

            migrationBuilder.DropTable(
                name: "Kamp");

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
        }
    }
}

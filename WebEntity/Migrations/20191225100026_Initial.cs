using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEntity.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ChequeIdNum",
                minValue: 1L,
                maxValue: 2147483647L,
                cyclic: true);

            migrationBuilder.CreateSequence<int>(
                name: "PositionIdNum",
                minValue: 1L,
                maxValue: 2147483647L,
                cyclic: true);

            migrationBuilder.CreateTable(
                name: "Cheques",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "next value for ChequeIdNum"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheques", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValueSql: "next value for PositionIdNum"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ChequeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Cheques_ChequeId",
                        column: x => x.ChequeId,
                        principalTable: "Cheques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_ChequeId",
                table: "Positions",
                column: "ChequeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Cheques");

            migrationBuilder.DropSequence(
                name: "ChequeIdNum");

            migrationBuilder.DropSequence(
                name: "PositionIdNum");
        }
    }
}

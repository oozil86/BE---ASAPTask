using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASAP.Infrastructure.Migrations
{
    public partial class AddIntgrationModelToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolygonResponse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueryCount = table.Column<int>(type: "int", nullable: false),
                    ResultsCount = table.Column<int>(type: "int", nullable: false),
                    Adjusted = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Reference = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolygonResponseResult",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V = table.Column<double>(type: "float", nullable: false),
                    VM = table.Column<double>(type: "float", nullable: false),
                    O = table.Column<double>(type: "float", nullable: false),
                    C = table.Column<double>(type: "float", nullable: false),
                    H = table.Column<double>(type: "float", nullable: false),
                    L = table.Column<double>(type: "float", nullable: false),
                    T = table.Column<double>(type: "float", nullable: false),
                    N = table.Column<double>(type: "float", nullable: false),
                    PolygonResponseId = table.Column<long>(type: "bigint", nullable: false),
                    Reference = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolygonResponseResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolygonResponseResult_PolygonResponse_PolygonResponseId",
                        column: x => x.PolygonResponseId,
                        principalTable: "PolygonResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolygonResponse_Reference",
                table: "PolygonResponse",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolygonResponseResult_PolygonResponseId",
                table: "PolygonResponseResult",
                column: "PolygonResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_PolygonResponseResult_Reference",
                table: "PolygonResponseResult",
                column: "Reference",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolygonResponseResult");

            migrationBuilder.DropTable(
                name: "PolygonResponse");
        }
    }
}

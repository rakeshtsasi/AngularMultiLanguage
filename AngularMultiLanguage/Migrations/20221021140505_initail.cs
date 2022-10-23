using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularMultiLanguage.Migrations
{
    public partial class initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAppLangMasters",
                columns: table => new
                {
                    LangCode = table.Column<string>(type: "varchar(2)", nullable: false),
                    LangName = table.Column<string>(type: "nvarchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAppLangMasters", x => x.LangCode);
                });

            migrationBuilder.CreateTable(
                name: "TblCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblCountryTrans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LangCode = table.Column<string>(type: "varchar(2)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCountryTrans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCountryTrans_TblAppLangMasters_LangCode",
                        column: x => x.LangCode,
                        principalTable: "TblAppLangMasters",
                        principalColumn: "LangCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblCountryTrans_TblCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "TblCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_LangCode",
                table: "TblCountryTrans",
                column: "LangCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCountryTrans");

            migrationBuilder.DropTable(
                name: "TblAppLangMasters");

            migrationBuilder.DropTable(
                name: "TblCountries");
        }
    }
}

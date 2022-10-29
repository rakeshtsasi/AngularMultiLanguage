using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AngularMultiLanguage.Migrations
{
    public partial class primarykeydefaultvalueandlangtablevalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans");

            migrationBuilder.DropIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountryTrans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TblAppLangMasters",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans",
                columns: new[] { "Id", "CountryId", "LangCode" });

            migrationBuilder.InsertData(
                table: "TblAppLangMasters",
                columns: new[] { "LangCode", "IsDefault", "LangName" },
                values: new object[] { "ar", false, "Arabic" });

            migrationBuilder.InsertData(
                table: "TblAppLangMasters",
                columns: new[] { "LangCode", "IsDefault", "LangName" },
                values: new object[] { "en", true, "English" });

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_CountryId_LangCode",
                table: "TblCountryTrans",
                columns: new[] { "CountryId", "LangCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblCountries_CreatedAt",
                table: "TblCountries",
                column: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans");

            migrationBuilder.DropIndex(
                name: "IX_TblCountryTrans_CountryId_LangCode",
                table: "TblCountryTrans");

            migrationBuilder.DropIndex(
                name: "IX_TblCountries_CreatedAt",
                table: "TblCountries");

            migrationBuilder.DeleteData(
                table: "TblAppLangMasters",
                keyColumn: "LangCode",
                keyValue: "ar");

            migrationBuilder.DeleteData(
                table: "TblAppLangMasters",
                keyColumn: "LangCode",
                keyValue: "en");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TblAppLangMasters");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountryTrans",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TblCountries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblCountryTrans",
                table: "TblCountryTrans",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TblCountryTrans_CountryId",
                table: "TblCountryTrans",
                column: "CountryId");
        }
    }
}

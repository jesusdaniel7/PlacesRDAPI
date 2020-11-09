using Microsoft.EntityFrameworkCore.Migrations;

namespace PlacesRDAPI.Migrations
{
    public partial class UpdatingPlaces1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Provinces_ProvinceID1",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ProvinceID1",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ProvinceID1",
                table: "Places");

            migrationBuilder.AlterColumn<int>(
                name: "ProvinceID",
                table: "Places",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_ProvinceID",
                table: "Places",
                column: "ProvinceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Provinces_ProvinceID",
                table: "Places",
                column: "ProvinceID",
                principalTable: "Provinces",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Provinces_ProvinceID",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_ProvinceID",
                table: "Places");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceID",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProvinceID1",
                table: "Places",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_ProvinceID1",
                table: "Places",
                column: "ProvinceID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Provinces_ProvinceID1",
                table: "Places",
                column: "ProvinceID1",
                principalTable: "Provinces",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

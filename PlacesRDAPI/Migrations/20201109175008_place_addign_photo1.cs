using Microsoft.EntityFrameworkCore.Migrations;

namespace PlacesRDAPI.Migrations
{
    public partial class place_addign_photo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Places",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

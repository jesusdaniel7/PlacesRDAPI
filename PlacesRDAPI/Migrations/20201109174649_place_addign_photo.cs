using Microsoft.EntityFrameworkCore.Migrations;

namespace PlacesRDAPI.Migrations
{
    public partial class place_addign_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Places",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Places");
        }
    }
}

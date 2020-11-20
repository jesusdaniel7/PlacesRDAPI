using Microsoft.EntityFrameworkCore.Migrations;

namespace PlacesRDAPI.Migrations
{
    public partial class placesphotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlacesPhotos",
                columns: table => new
                {
                    PlacePhotosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PlaceID = table.Column<int>(nullable: false),
                    photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesPhotos", x => x.PlacePhotosID);
                    table.ForeignKey(
                        name: "FK_PlacesPhotos_Places_PlaceID",
                        column: x => x.PlaceID,
                        principalTable: "Places",
                        principalColumn: "PlaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacesPhotos_PlaceID",
                table: "PlacesPhotos",
                column: "PlaceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacesPhotos");
        }
    }
}

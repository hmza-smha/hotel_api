using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Add_RoomAmenity_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Rooms_RoomHotelId_RoomNumber",
                table: "Amenities");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomHotelId_RoomNumber",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomHotelId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Amenities");

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomHotelId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.RoomId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_RoomHotelId_RoomNumber",
                        columns: x => new { x.RoomHotelId, x.RoomNumber },
                        principalTable: "Rooms",
                        principalColumns: new[] { "HotelId", "RoomNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "7d1bd008-1071-41db-b7cd-13665646e3ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d744fe07-9e96-4880-9426-62573572ed6c", "AQAAAAEAACcQAAAAENWviVlRQcZqHA392jMEqmn58gLNLSVUd8cgPCVlGZp/7CNcchAvPIEC7R03Op+e5A==" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomHotelId_RoomNumber",
                table: "RoomAmenities",
                columns: new[] { "RoomHotelId", "RoomNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.AddColumn<int>(
                name: "RoomHotelId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "12be2b10-fe93-447a-a4c4-55cde07e2177");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1bc4e2f-55a7-4457-a2d5-56db4577202a", "AQAAAAEAACcQAAAAEC/xQpbm2hS3EUIYzbCfEGO70HhbJeEX/TFrFdGoowCpsJ8iCHSpBcFXK3zMxuorVQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomHotelId_RoomNumber",
                table: "Amenities",
                columns: new[] { "RoomHotelId", "RoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_Rooms_RoomHotelId_RoomNumber",
                table: "Amenities",
                columns: new[] { "RoomHotelId", "RoomNumber" },
                principalTable: "Rooms",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

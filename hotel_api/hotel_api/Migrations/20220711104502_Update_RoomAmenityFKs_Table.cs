using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Update_RoomAmenityFKs_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomHotelId_RoomNumber1",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_RoomHotelId_RoomNumber1",
                table: "RoomAmenities");

            migrationBuilder.DropColumn(
                name: "RoomHotelId",
                table: "RoomAmenities");

            migrationBuilder.DropColumn(
                name: "RoomNumber1",
                table: "RoomAmenities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "c9dedb13-758c-4b6b-bb3a-dd6c056a23a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5dcd141e-4a3a-49aa-8858-4dc615db056e", "AQAAAAEAACcQAAAAEABa14w4kxGPFzfW8mLek54fcmGSjN2UesljnILSi21BKZuFCRkLvo8P7nailiqt5A==" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_HotelId_RoomNumber",
                table: "RoomAmenities",
                columns: new[] { "HotelId", "RoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_HotelId_RoomNumber",
                table: "RoomAmenities",
                columns: new[] { "HotelId", "RoomNumber" },
                principalTable: "Rooms",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_HotelId_RoomNumber",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_HotelId_RoomNumber",
                table: "RoomAmenities");

            migrationBuilder.AddColumn<int>(
                name: "RoomHotelId",
                table: "RoomAmenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber1",
                table: "RoomAmenities",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "501de264-303a-4467-8a2c-96d8ab7d88a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5f8a955-0c38-4819-8aa0-b24a3b8f67bc", "AQAAAAEAACcQAAAAEIPEcUqBQo3VsQ9uVKPcMU/T0ysEGx3Xe5BP9I+1zK3Qj/3ldhxhX7PI7zp74jYgKg==" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomHotelId_RoomNumber1",
                table: "RoomAmenities",
                columns: new[] { "RoomHotelId", "RoomNumber1" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomHotelId_RoomNumber1",
                table: "RoomAmenities",
                columns: new[] { "RoomHotelId", "RoomNumber1" },
                principalTable: "Rooms",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

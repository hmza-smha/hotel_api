using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Update_RoomAmenityPKs_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomHotelId_RoomNumber",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_RoomHotelId_RoomNumber",
                table: "RoomAmenities");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "RoomAmenities",
                newName: "HotelId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomHotelId",
                table: "RoomAmenities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber1",
                table: "RoomAmenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                columns: new[] { "RoomNumber", "AmenityId", "HotelId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomHotelId_RoomNumber1",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities");

            migrationBuilder.DropIndex(
                name: "IX_RoomAmenities_RoomHotelId_RoomNumber1",
                table: "RoomAmenities");

            migrationBuilder.DropColumn(
                name: "RoomNumber1",
                table: "RoomAmenities");

            migrationBuilder.RenameColumn(
                name: "HotelId",
                table: "RoomAmenities",
                newName: "RoomId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomHotelId",
                table: "RoomAmenities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenities",
                table: "RoomAmenities",
                columns: new[] { "RoomId", "AmenityId" });

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
                name: "IX_RoomAmenities_RoomHotelId_RoomNumber",
                table: "RoomAmenities",
                columns: new[] { "RoomHotelId", "RoomNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomHotelId_RoomNumber",
                table: "RoomAmenities",
                columns: new[] { "RoomHotelId", "RoomNumber" },
                principalTable: "Rooms",
                principalColumns: new[] { "HotelId", "RoomNumber" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

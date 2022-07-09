using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name", "RoomHotelId", "RoomNumber" },
                values: new object[,]
                {
                    { 1, "TV", null, null },
                    { 2, "Cofee Machine", null, null },
                    { 3, "Ocean View", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad376a8f", "f14eeb21-2062-4519-bff9-a2934ab8b80f", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0", 0, "efe33e33-adb9-4d1b-8945-764c7e02869a", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEO0DJjYRF+Fzl9qAb1FYmBgVGEXVq/l1PJFhMgKqEk0uIfU1cDWgpKzMOBnowa+7jQ==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "Amman", "Jordan", "Async Inn", "06-485236", "Available" },
                    { 2, "Irbid", "Jordan", "Async Inn", "06-485236", "Closed" },
                    { 3, "Aqaba", "Jordan", "Async Inn", "06-485236", "Available" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad376a8f", "a18be9c0" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "HotelId", "RoomNumber", "CustomerId", "Phone", "Price", "Rate", "Status" },
                values: new object[,]
                {
                    { 1, 1, null, 123, null, null, null },
                    { 1, 2, null, 124, null, null, null },
                    { 1, 3, null, 125, null, null, null },
                    { 2, 1, null, 122, null, null, null },
                    { 3, 1, null, 124, null, null, null },
                    { 3, 2, null, 125, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f", "a18be9c0" });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Init_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => new { x.HotelId, x.RoomNumber });
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_CustomerUsername",
                        column: x => x.CustomerUsername,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.RoomNumber, x.AmenityId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_HotelId_RoomNumber",
                        columns: x => new { x.HotelId, x.RoomNumber },
                        principalTable: "Rooms",
                        principalColumns: new[] { "HotelId", "RoomNumber" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TV" },
                    { 2, "Cofee Machine" },
                    { 3, "Ocean View" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { 1, "Amman", "Jordan", "amman-hotel", "06-485236", "Available" },
                    { 2, "Irbid", "Jordan", "irbid-hotel", "06-485236", "Closed" },
                    { 3, "Aqaba", "Jordan", "aqaba-hotel", "06-485236", "Available" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { "Admin", "123", "0786371281", "Admin" },
                    { "HamZa", "123", "0786371281", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "HotelId", "RoomNumber", "CustomerUsername", "Phone", "Price", "Rate", "Status" },
                values: new object[,]
                {
                    { 1, 3, null, 125, 15m, 5m, "Available" },
                    { 1, 4, null, 512, 10m, 4m, "Available" },
                    { 2, 1, null, 124, 30m, 4m, "Available" },
                    { 2, 2, null, 122, 15m, 4m, "Available" },
                    { 2, 3, null, 231, 10m, 4m, "Available" },
                    { 3, 1, null, 124, 20m, 5m, "Available" },
                    { 3, 3, null, 145, 20m, 5m, "Available" },
                    { 1, 2, "Admin", 124, 20m, 4m, "Booked By Admin" },
                    { 1, 1, "HamZa", 123, 15m, 5m, "Booked By HamZa" },
                    { 3, 2, "HamZa", 125, 15m, 5m, "Booked By HamZa" }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "AmenityId", "HotelId", "RoomNumber", "Status" },
                values: new object[,]
                {
                    { 1, 1, 3, null },
                    { 2, 1, 3, null },
                    { 1, 1, 4, null },
                    { 1, 2, 1, null },
                    { 2, 2, 1, null },
                    { 3, 2, 2, null },
                    { 2, 2, 2, null },
                    { 1, 3, 1, null },
                    { 3, 1, 2, null },
                    { 2, 1, 2, null },
                    { 1, 1, 1, null },
                    { 2, 1, 1, null },
                    { 3, 1, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_HotelId_RoomNumber",
                table: "RoomAmenities",
                columns: new[] { "HotelId", "RoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustomerUsername",
                table: "Rooms",
                column: "CustomerUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

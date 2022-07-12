using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Update_PK_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_CustomerId",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "CustomerUsername",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustomerUsername",
                table: "Rooms",
                column: "CustomerUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_CustomerUsername",
                table: "Rooms",
                column: "CustomerUsername",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_CustomerUsername",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CustomerUsername",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustomerUsername",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_CustomerId",
                table: "Rooms",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

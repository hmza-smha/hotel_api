using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Update_Rooms_User_FK_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_CustomerId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Rooms",
                newName: "CustomerUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms",
                newName: "IX_Rooms_CustomerUsername");

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

            migrationBuilder.RenameColumn(
                name: "CustomerUsername",
                table: "Rooms",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_CustomerUsername",
                table: "Rooms",
                newName: "IX_Rooms_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_CustomerId",
                table: "Rooms",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

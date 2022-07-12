using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class Update_Rooms_User_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_CustomerUsername",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CustomerUsername",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CustomerUsername",
                table: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_CustomerId",
                table: "Rooms",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_CustomerId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CustomerId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerUsername",
                table: "Rooms",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_api.Migrations
{
    public partial class update_asp_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f",
                column: "ConcurrencyStamp",
                value: "c57c3d79-f026-4602-951f-ec2ec68d5175");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f395ddc1-81b2-4933-b09d-695e0680775b", "AQAAAAEAACcQAAAAEBrj5AT1BGqLnXnpJZydIGKbnPvl8BPId3ETTbRs0WqhmTBFBorHY2XT7m6ZCyYf2g==" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    public partial class GeneracionTablas8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "171e0aac-219c-495b-8979-61c0ece2572f",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDpStpGprcVKdWJ25WDXiUBGRPMCkgEFKZjFcTPWWe7k1i0KJITxcFRqdCyjDhVAeQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c16bc907-86de-4762-b334-d0c923588ffc",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHwwgsc2WrK+wVDVxvAfaVeiwoix8QsqiGc+iD8SL71i2DySV2J/8LuW/8l5g2Fg3A==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "171e0aac-219c-495b-8979-61c0ece2572f",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGM7kkkYsY4f4ffr5P4z39Fk2dzaXjVE6Pi/TW2NUcpjTVToIIaMuNGbyJYVCXMaXQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c16bc907-86de-4762-b334-d0c923588ffc",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEEewcz7hHpH3+EujIHKhmS5yqXqGamXiCU2dsEMmeQwzpH05t6XFUIIIHUtwA0Tqew==");
        }
    }
}
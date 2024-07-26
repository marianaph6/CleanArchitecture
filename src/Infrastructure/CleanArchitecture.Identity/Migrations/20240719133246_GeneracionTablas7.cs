using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    public partial class GeneracionTablas7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "171e0aac-219c-495b-8979-61c0ece2572f",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJpDq51C1Xcs/IrWu328RinMmuxoiGMHZrjPuhGNHeqzaONTaIlYUynFvCRRqnkR/w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c16bc907-86de-4762-b334-d0c923588ffc",
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEP8jngU39Pb18cQpxy90qrHRT9n1+2bE+ak2CIE+hS3Qiotvky7ZTTSHTOdK3lB3eQ==");
        }
    }
}
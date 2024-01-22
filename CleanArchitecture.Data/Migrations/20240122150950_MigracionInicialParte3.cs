using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    public partial class MigracionInicialParte3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videoa_Streamers_StreamerId",
                table: "Videoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videoa",
                table: "Videoa");

            migrationBuilder.RenameTable(
                name: "Videoa",
                newName: "Videos");

            migrationBuilder.RenameIndex(
                name: "IX_Videoa_StreamerId",
                table: "Videos",
                newName: "IX_Videos_StreamerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos",
                column: "StreamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.RenameTable(
                name: "Videos",
                newName: "Videoa");

            migrationBuilder.RenameIndex(
                name: "IX_Videos_StreamerId",
                table: "Videoa",
                newName: "IX_Videoa_StreamerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videoa",
                table: "Videoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videoa_Streamers_StreamerId",
                table: "Videoa",
                column: "StreamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

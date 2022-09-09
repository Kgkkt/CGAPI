using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGAPI.Migrations
{
    public partial class innit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CG_GameElements_CG_Sounds_CG_SoundAnswerId",
                table: "CG_GameElements");

            migrationBuilder.RenameColumn(
                name: "CG_SoundAnswerId",
                table: "CG_GameElements",
                newName: "CG_SoundWrongAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_CG_GameElements_CG_SoundAnswerId",
                table: "CG_GameElements",
                newName: "IX_CG_GameElements_CG_SoundWrongAnswerId");

            migrationBuilder.AddColumn<int>(
                name: "CG_SoundCorrectAnswerId",
                table: "CG_GameElements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CG_GameElements_CG_SoundCorrectAnswerId",
                table: "CG_GameElements",
                column: "CG_SoundCorrectAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CG_GameElements_CG_Sounds_CG_SoundCorrectAnswerId",
                table: "CG_GameElements",
                column: "CG_SoundCorrectAnswerId",
                principalTable: "CG_Sounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CG_GameElements_CG_Sounds_CG_SoundWrongAnswerId",
                table: "CG_GameElements",
                column: "CG_SoundWrongAnswerId",
                principalTable: "CG_Sounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CG_GameElements_CG_Sounds_CG_SoundCorrectAnswerId",
                table: "CG_GameElements");

            migrationBuilder.DropForeignKey(
                name: "FK_CG_GameElements_CG_Sounds_CG_SoundWrongAnswerId",
                table: "CG_GameElements");

            migrationBuilder.DropIndex(
                name: "IX_CG_GameElements_CG_SoundCorrectAnswerId",
                table: "CG_GameElements");

            migrationBuilder.DropColumn(
                name: "CG_SoundCorrectAnswerId",
                table: "CG_GameElements");

            migrationBuilder.RenameColumn(
                name: "CG_SoundWrongAnswerId",
                table: "CG_GameElements",
                newName: "CG_SoundAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_CG_GameElements_CG_SoundWrongAnswerId",
                table: "CG_GameElements",
                newName: "IX_CG_GameElements_CG_SoundAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CG_GameElements_CG_Sounds_CG_SoundAnswerId",
                table: "CG_GameElements",
                column: "CG_SoundAnswerId",
                principalTable: "CG_Sounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

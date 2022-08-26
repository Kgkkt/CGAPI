using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CGAPI.Migrations
{
    public partial class addGameElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CG_GameElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CG_ImageId = table.Column<int>(type: "int", nullable: false),
                    CG_SoundQuestionId = table.Column<int>(type: "int", nullable: false),
                    CG_SoundAnswerId = table.Column<int>(type: "int", nullable: false),
                    CG_PlaylistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CG_GameElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CG_GameElements_CG_Images_CG_ImageId",
                        column: x => x.CG_ImageId,
                        principalTable: "CG_Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CG_GameElements_CG_Playlists_CG_PlaylistId",
                        column: x => x.CG_PlaylistId,
                        principalTable: "CG_Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CG_GameElements_CG_Sounds_CG_SoundAnswerId",
                        column: x => x.CG_SoundAnswerId,
                        principalTable: "CG_Sounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CG_GameElements_CG_Sounds_CG_SoundQuestionId",
                        column: x => x.CG_SoundQuestionId,
                        principalTable: "CG_Sounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CG_GameElements_CG_ImageId",
                table: "CG_GameElements",
                column: "CG_ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CG_GameElements_CG_PlaylistId",
                table: "CG_GameElements",
                column: "CG_PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_CG_GameElements_CG_SoundAnswerId",
                table: "CG_GameElements",
                column: "CG_SoundAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_CG_GameElements_CG_SoundQuestionId",
                table: "CG_GameElements",
                column: "CG_SoundQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CG_GameElements");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplikacja2.Migrations
{
    /// <inheritdoc />
    public partial class dodanie_pol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategorie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__kategori__3213E83F67C52F77", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tagi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tagi__3213E83FAB4AFFC2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "uzytkownicy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    haslo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__uzytkown__3213E83F186BCE24", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tytul = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_utworzenia = table.Column<DateTime>(type: "datetime", nullable: false),
                    uzytkownik_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__post__3213E83F747EAAA3", x => x.id);
                    table.ForeignKey(
                        name: "FK__post__uzytkownik__398D8EEE",
                        column: x => x.uzytkownik_id,
                        principalTable: "uzytkownicy",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "komentarze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uzytkownik_id = table.Column<int>(type: "int", nullable: true),
                    post_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__komentar__3213E83FB3F9E713", x => x.id);
                    table.ForeignKey(
                        name: "FK__komentarz__post___4316F928",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__komentarz__uzytk__4222D4EF",
                        column: x => x.uzytkownik_id,
                        principalTable: "uzytkownicy",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "post_kategorie",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false),
                    kategoria_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__post_kat__23A3DBF287AAA5E6", x => new { x.post_id, x.kategoria_id });
                    table.ForeignKey(
                        name: "FK__post_kate__kateg__3F466844",
                        column: x => x.kategoria_id,
                        principalTable: "kategorie",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__post_kate__post___3E52440B",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "post_tagi",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false),
                    tag_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__post_tag__4AFEED4D83382A9C", x => new { x.post_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK__post_tagi__post___47DBAE45",
                        column: x => x.post_id,
                        principalTable: "post",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__post_tagi__tag_i__48CFD27E",
                        column: x => x.tag_id,
                        principalTable: "tagi",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PostKategorie",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostKategorie", x => new { x.PostId, x.KategoriaId });
                    table.ForeignKey(
                        name: "FK_PostKategorie_kategorie_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "kategorie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostKategorie_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_komentarze_post_id",
                table: "komentarze",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_komentarze_uzytkownik_id",
                table: "komentarze",
                column: "uzytkownik_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_uzytkownik_id",
                table: "post",
                column: "uzytkownik_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_kategorie_kategoria_id",
                table: "post_kategorie",
                column: "kategoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_post_tagi_tag_id",
                table: "post_tagi",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_PostKategorie_KategoriaId",
                table: "PostKategorie",
                column: "KategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "komentarze");

            migrationBuilder.DropTable(
                name: "post_kategorie");

            migrationBuilder.DropTable(
                name: "post_tagi");

            migrationBuilder.DropTable(
                name: "PostKategorie");

            migrationBuilder.DropTable(
                name: "tagi");

            migrationBuilder.DropTable(
                name: "kategorie");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "uzytkownicy");
        }
    }
}

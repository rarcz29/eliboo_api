using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Eliboo.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "libraries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    access_token = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_libraries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bookshelves",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    library_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookshelves", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookshelves_libraries_library_id",
                        column: x => x.library_id,
                        principalTable: "libraries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    library_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_libraries_library_id",
                        column: x => x.library_id,
                        principalTable: "libraries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    author = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    genre = table.Column<string>(type: "text", nullable: true),
                    bookshelf_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_books_bookshelves_bookshelf_id",
                        column: x => x.bookshelf_id,
                        principalTable: "bookshelves",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "my_list",
                columns: table => new
                {
                    books_id = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_my_list", x => new { x.books_id, x.users_id });
                    table.ForeignKey(
                        name: "fk_my_list_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_my_list_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_bookshelf_id",
                table: "books",
                column: "bookshelf_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookshelves_library_id_description",
                table: "bookshelves",
                columns: new[] { "library_id", "description" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_libraries_access_token",
                table: "libraries",
                column: "access_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_my_list_users_id",
                table: "my_list",
                column: "users_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_library_id",
                table: "users",
                column: "library_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "my_list");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "bookshelves");

            migrationBuilder.DropTable(
                name: "libraries");
        }
    }
}

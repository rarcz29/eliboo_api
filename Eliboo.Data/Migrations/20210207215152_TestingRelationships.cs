using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Eliboo.Data.Migrations
{
    public partial class TestingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_bookshelves_bookshelf_id",
                table: "books");

            migrationBuilder.DropTable(
                name: "reading_now");

            migrationBuilder.DropIndex(
                name: "ix_my_list_books_id",
                table: "my_list");

            migrationBuilder.DropIndex(
                name: "ix_books_bookshelf_id",
                table: "books");

            migrationBuilder.DropColumn(
                name: "bookshelf_id",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "libraries_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "books",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "books",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_my_list",
                table: "my_list",
                columns: new[] { "books_id", "users_id" });

            migrationBuilder.CreateTable(
                name: "libraries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    access_token = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_libraries", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_libraries_id",
                table: "users",
                column: "libraries_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_libraries_libraries_id",
                table: "users",
                column: "libraries_id",
                principalTable: "libraries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_libraries_libraries_id",
                table: "users");

            migrationBuilder.DropTable(
                name: "libraries");

            migrationBuilder.DropIndex(
                name: "ix_users_libraries_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_my_list",
                table: "my_list");

            migrationBuilder.DropColumn(
                name: "libraries_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "title",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "books",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bookshelf_id",
                table: "books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "reading_now",
                columns: table => new
                {
                    books_id = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "fk_reading_now_books_books_id",
                        column: x => x.books_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reading_now_users_users_id",
                        column: x => x.users_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_my_list_books_id",
                table: "my_list",
                column: "books_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_bookshelf_id",
                table: "books",
                column: "bookshelf_id");

            migrationBuilder.CreateIndex(
                name: "ix_reading_now_books_id",
                table: "reading_now",
                column: "books_id");

            migrationBuilder.CreateIndex(
                name: "ix_reading_now_users_id",
                table: "reading_now",
                column: "users_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_bookshelves_bookshelf_id",
                table: "books",
                column: "bookshelf_id",
                principalTable: "bookshelves",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

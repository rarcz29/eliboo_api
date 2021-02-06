using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Eliboo.Data.Migrations
{
    public partial class SnakeCaseNamingConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Bookshelves_BookshelfId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookshelves",
                table: "Bookshelves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Bookshelves",
                newName: "bookshelves");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "books");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "bookshelves",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bookshelves",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "books",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "books",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "books",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BookshelfId",
                table: "books",
                newName: "bookshelf_id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookshelfId",
                table: "books",
                newName: "ix_books_bookshelf_id");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "bookshelves",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "books",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "author",
                table: "books",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "pk_bookshelves",
                table: "bookshelves",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_books",
                table: "books",
                column: "id");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nickname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    password = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "my_list",
                columns: table => new
                {
                    users_id = table.Column<int>(type: "integer", nullable: false),
                    books_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.CreateTable(
                name: "reading_now",
                columns: table => new
                {
                    users_id = table.Column<int>(type: "integer", nullable: false),
                    books_id = table.Column<int>(type: "integer", nullable: false)
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
                name: "ix_my_list_users_id",
                table: "my_list",
                column: "users_id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_bookshelves_bookshelf_id",
                table: "books");

            migrationBuilder.DropTable(
                name: "my_list");

            migrationBuilder.DropTable(
                name: "reading_now");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_bookshelves",
                table: "bookshelves");

            migrationBuilder.DropPrimaryKey(
                name: "pk_books",
                table: "books");

            migrationBuilder.RenameTable(
                name: "bookshelves",
                newName: "Bookshelves");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Bookshelves",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bookshelves",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Books",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "bookshelf_id",
                table: "Books",
                newName: "BookshelfId");

            migrationBuilder.RenameIndex(
                name: "ix_books_bookshelf_id",
                table: "Books",
                newName: "IX_Books_BookshelfId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Bookshelves",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookshelves",
                table: "Bookshelves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Bookshelves_BookshelfId",
                table: "Books",
                column: "BookshelfId",
                principalTable: "Bookshelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Eliboo.Infrastructure.Migrations
{
    public partial class ReadinNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "current_reading_id",
                table: "users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_current_reading_id",
                table: "users",
                column: "current_reading_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_books_current_reading_id",
                table: "users",
                column: "current_reading_id",
                principalTable: "books",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_books_current_reading_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_current_reading_id",
                table: "users");

            migrationBuilder.DropColumn(
                name: "current_reading_id",
                table: "users");
        }
    }
}

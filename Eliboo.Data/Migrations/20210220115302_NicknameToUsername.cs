using Microsoft.EntityFrameworkCore.Migrations;

namespace Eliboo.Data.Migrations
{
    public partial class NicknameToUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "users",
                newName: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "users",
                newName: "nickname");
        }
    }
}

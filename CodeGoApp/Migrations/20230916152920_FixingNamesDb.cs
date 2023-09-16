using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeGoApp.Migrations
{
    public partial class FixingNamesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MsgCreatedTime",
                table: "AspNetUsers",
                newName: "UserCreatedTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCreatedTime",
                table: "AspNetUsers",
                newName: "MsgCreatedTime");
        }
    }
}

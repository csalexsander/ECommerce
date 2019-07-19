using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce_Repository.Migrations
{
    public partial class userforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "User",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RoleId",
                table: "User",
                nullable: true,
                oldClrType: typeof(long));
        }
    }
}

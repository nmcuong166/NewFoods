using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsFood.Infurstructure.Migrations
{
    public partial class updateProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Parent_Id",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Parent_Id",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}

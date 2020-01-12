using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsFood.Infurstructure.Migrations
{
    public partial class updateDbCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parent_Id",
                table: "Categories",
                newName: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Categories",
                newName: "Parent_Id");
        }
    }
}

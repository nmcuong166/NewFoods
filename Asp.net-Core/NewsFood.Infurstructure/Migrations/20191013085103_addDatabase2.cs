using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsFood.Infurstructure.Migrations
{
    public partial class addDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NewsDetails_NewsId",
                table: "NewsDetails",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDetails_News_NewsId",
                table: "NewsDetails",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsDetails_News_NewsId",
                table: "NewsDetails");

            migrationBuilder.DropIndex(
                name: "IX_NewsDetails_NewsId",
                table: "NewsDetails");
        }
    }
}

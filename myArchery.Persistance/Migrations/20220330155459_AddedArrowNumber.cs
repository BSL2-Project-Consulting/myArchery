using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myArchery.Persistance.Migrations
{
    public partial class AddedArrowNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArrowNumber",
                table: "Point",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrowNumber",
                table: "Point");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Nihongo.Entites.Migrations
{
    public partial class changepropertycolumn__highlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HighLight",
                table: "Properties",
                newName: "HighLights");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HighLights",
                table: "Properties",
                newName: "HighLight");
        }
    }
}

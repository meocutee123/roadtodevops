using Microsoft.EntityFrameworkCore.Migrations;

namespace Nihongo.Entites.Migrations
{
    public partial class changeotherdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Key",
                table: "PropertyAdditionalInformation",
                newName: "Label");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "LandlordOtherDetail",
                newName: "Label");

            migrationBuilder.AddColumn<string>(
                name: "FieldAlias",
                table: "PropertyAdditionalInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldAlias",
                table: "LandlordOtherDetail",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldAlias",
                table: "PropertyAdditionalInformation");

            migrationBuilder.DropColumn(
                name: "FieldAlias",
                table: "LandlordOtherDetail");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "PropertyAdditionalInformation",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "LandlordOtherDetail",
                newName: "Key");
        }
    }
}

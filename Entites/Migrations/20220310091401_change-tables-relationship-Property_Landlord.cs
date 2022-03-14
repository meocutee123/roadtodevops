using Microsoft.EntityFrameworkCore.Migrations;

namespace Nihongo.Entites.Migrations
{
    public partial class changetablesrelationshipProperty_Landlord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Landlords_LandlordId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_LandlordId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Buildings");

            migrationBuilder.AddColumn<int>(
                name: "LandlordId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties",
                column: "LandlordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordId",
                table: "Properties",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "LandlordId",
                table: "Buildings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LandlordId",
                table: "Buildings",
                column: "LandlordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Landlords_LandlordId",
                table: "Buildings",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

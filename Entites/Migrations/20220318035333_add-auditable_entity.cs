using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nihongo.Entites.Migrations
{
    public partial class addauditable_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptTerms",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Accounts",
                newName: "Modified");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Properties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Landlords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Landlords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Landlords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Landlords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Buildings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Buildings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Buildings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CreatedBy",
                table: "Properties",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LastModifiedBy",
                table: "Properties",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_CreatedBy",
                table: "Landlords",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_LastModifiedBy",
                table: "Landlords",
                column: "LastModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CreatedBy",
                table: "Buildings",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_LastModifiedBy",
                table: "Buildings",
                column: "LastModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Accounts_CreatedBy",
                table: "Buildings",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Accounts_LastModifiedBy",
                table: "Buildings",
                column: "LastModifiedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_Accounts_CreatedBy",
                table: "Landlords",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_Accounts_LastModifiedBy",
                table: "Landlords",
                column: "LastModifiedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Accounts_CreatedBy",
                table: "Properties",
                column: "CreatedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Accounts_LastModifiedBy",
                table: "Properties",
                column: "LastModifiedBy",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Accounts_CreatedBy",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Accounts_LastModifiedBy",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_Accounts_CreatedBy",
                table: "Landlords");

            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_Accounts_LastModifiedBy",
                table: "Landlords");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Accounts_CreatedBy",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Accounts_LastModifiedBy",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_CreatedBy",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LastModifiedBy",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_CreatedBy",
                table: "Landlords");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_LastModifiedBy",
                table: "Landlords");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_CreatedBy",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_LastModifiedBy",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Accounts",
                newName: "Updated");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptTerms",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

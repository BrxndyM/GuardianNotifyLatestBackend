using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardianNotifyBackend.Migrations
{
    /// <inheritdoc />
    public partial class M20240918215400 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "CloseContacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CloseContacts_PersonId",
                table: "CloseContacts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CloseContacts_Persons_PersonId",
                table: "CloseContacts",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CloseContacts_Persons_PersonId",
                table: "CloseContacts");

            migrationBuilder.DropIndex(
                name: "IX_CloseContacts_PersonId",
                table: "CloseContacts");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "CloseContacts");
        }
    }
}

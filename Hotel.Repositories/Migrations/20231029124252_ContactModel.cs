using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Repositories.Migrations
{
    public partial class ContactModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_HotelInfos_HotelInfoId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_HotelInfoId",
                table: "Contacts",
                newName: "IX_Contacts_HotelInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_HotelInfos_HotelInfoId",
                table: "Contacts",
                column: "HotelInfoId",
                principalTable: "HotelInfos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_HotelInfos_HotelInfoId",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_HotelInfoId",
                table: "Contact",
                newName: "IX_Contact_HotelInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_HotelInfos_HotelInfoId",
                table: "Contact",
                column: "HotelInfoId",
                principalTable: "HotelInfos",
                principalColumn: "Id");
        }
    }
}

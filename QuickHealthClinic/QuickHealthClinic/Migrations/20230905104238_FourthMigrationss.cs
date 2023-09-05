using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickLifeCoachingClinic.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigrationss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Addresses_AddressId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Addresses_AddressId",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Addresses_AddressId",
                table: "Clinics",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Addresses_AddressId",
                table: "Mentors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_Addresses_AddressId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Addresses_AddressId",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_Addresses_AddressId",
                table: "Clinics",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Addresses_AddressId",
                table: "Mentors",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

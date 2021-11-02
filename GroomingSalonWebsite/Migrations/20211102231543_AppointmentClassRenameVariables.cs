using Microsoft.EntityFrameworkCore.Migrations;

namespace GroomingSalonWebsite.Migrations
{
    public partial class AppointmentClassRenameVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetWeight",
                table: "Appointment",
                newName: "AppointmentPetWeight");

            migrationBuilder.RenameColumn(
                name: "PetName",
                table: "Appointment",
                newName: "AppointmentPetName");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Appointment",
                newName: "AppointmentPetBreed");

            migrationBuilder.RenameColumn(
                name: "PetBirthday",
                table: "Appointment",
                newName: "AppointmentPetBirthday");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Appointment",
                newName: "AppointmentLastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Appointment",
                newName: "AppointmentFirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentPetWeight",
                table: "Appointment",
                newName: "PetWeight");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetName",
                table: "Appointment",
                newName: "PetName");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetBreed",
                table: "Appointment",
                newName: "PetBreed");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetBirthday",
                table: "Appointment",
                newName: "PetBirthday");

            migrationBuilder.RenameColumn(
                name: "AppointmentLastName",
                table: "Appointment",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AppointmentFirstName",
                table: "Appointment",
                newName: "FirstName");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GroomingSalonWebsite.Migrations
{
    public partial class AppointmentRenameFull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "Appointment",
                newName: "ApptZipcode");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Appointment",
                newName: "ApptState");

            migrationBuilder.RenameColumn(
                name: "Services",
                table: "Appointment",
                newName: "ApptServices");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Appointment",
                newName: "ApptPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Appointment",
                newName: "ApptPetName");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetWeight",
                table: "Appointment",
                newName: "ApptPetWeight");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetName",
                table: "Appointment",
                newName: "ApptPetBreed");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetBreed",
                table: "Appointment",
                newName: "ApptLastName");

            migrationBuilder.RenameColumn(
                name: "AppointmentPetBirthday",
                table: "Appointment",
                newName: "ApptPetBirthDay");

            migrationBuilder.RenameColumn(
                name: "AppointmentLastName",
                table: "Appointment",
                newName: "ApptFirstName");

            migrationBuilder.RenameColumn(
                name: "AppointmentFirstName",
                table: "Appointment",
                newName: "ApptCity");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointment",
                newName: "ApptDate");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "Appointment",
                newName: "ApptAddress2");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "Appointment",
                newName: "ApptAddress1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApptZipcode",
                table: "Appointment",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "ApptState",
                table: "Appointment",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ApptServices",
                table: "Appointment",
                newName: "Services");

            migrationBuilder.RenameColumn(
                name: "ApptPhoneNumber",
                table: "Appointment",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ApptPetWeight",
                table: "Appointment",
                newName: "AppointmentPetWeight");

            migrationBuilder.RenameColumn(
                name: "ApptPetName",
                table: "Appointment",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ApptPetBreed",
                table: "Appointment",
                newName: "AppointmentPetName");

            migrationBuilder.RenameColumn(
                name: "ApptPetBirthDay",
                table: "Appointment",
                newName: "AppointmentPetBirthday");

            migrationBuilder.RenameColumn(
                name: "ApptLastName",
                table: "Appointment",
                newName: "AppointmentPetBreed");

            migrationBuilder.RenameColumn(
                name: "ApptFirstName",
                table: "Appointment",
                newName: "AppointmentLastName");

            migrationBuilder.RenameColumn(
                name: "ApptDate",
                table: "Appointment",
                newName: "AppointmentDate");

            migrationBuilder.RenameColumn(
                name: "ApptCity",
                table: "Appointment",
                newName: "AppointmentFirstName");

            migrationBuilder.RenameColumn(
                name: "ApptAddress2",
                table: "Appointment",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "ApptAddress1",
                table: "Appointment",
                newName: "Address1");
        }
    }
}

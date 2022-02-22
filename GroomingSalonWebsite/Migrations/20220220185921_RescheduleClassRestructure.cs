using Microsoft.EntityFrameworkCore.Migrations;

namespace GroomingSalonWebsite.Migrations
{
    public partial class RescheduleClassRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reschedules",
                columns: table => new
                {
                    RescheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(nullable: true),
                    Confirmation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reschedules", x => x.RescheduleId);
                    table.ForeignKey(
                        name: "FK_Reschedules_Appointment_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reschedules_AppointmentId",
                table: "Reschedules",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reschedules");
        }
    }
}

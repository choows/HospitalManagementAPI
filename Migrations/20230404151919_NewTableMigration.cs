using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NonPatientAppointmentId",
                table: "_prescriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "_nonPatientAppointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientNric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__nonPatientAppointments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX__prescriptions_NonPatientAppointmentId",
                table: "_prescriptions",
                column: "NonPatientAppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK__prescriptions__nonPatientAppointments_NonPatientAppointmentId",
                table: "_prescriptions",
                column: "NonPatientAppointmentId",
                principalTable: "_nonPatientAppointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__prescriptions__nonPatientAppointments_NonPatientAppointmentId",
                table: "_prescriptions");

            migrationBuilder.DropTable(
                name: "_nonPatientAppointments");

            migrationBuilder.DropIndex(
                name: "IX__prescriptions_NonPatientAppointmentId",
                table: "_prescriptions");

            migrationBuilder.DropColumn(
                name: "NonPatientAppointmentId",
                table: "_prescriptions");
        }
    }
}

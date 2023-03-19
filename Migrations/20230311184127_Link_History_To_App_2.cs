using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Link_History_To_App_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__prescriptions__medicines_medicineId",
                table: "_prescriptions");

            migrationBuilder.DropIndex(
                name: "IX__prescriptions_medicineId",
                table: "_prescriptions");

            migrationBuilder.DropColumn(
                name: "medicineId",
                table: "_prescriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "_prescriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "_medicines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX__prescriptions_AppointmentId",
                table: "_prescriptions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX__medicines_PrescriptionId",
                table: "_medicines",
                column: "PrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK__medicines__prescriptions_PrescriptionId",
                table: "_medicines",
                column: "PrescriptionId",
                principalTable: "_prescriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__prescriptions__appointments_AppointmentId",
                table: "_prescriptions",
                column: "AppointmentId",
                principalTable: "_appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__medicines__prescriptions_PrescriptionId",
                table: "_medicines");

            migrationBuilder.DropForeignKey(
                name: "FK__prescriptions__appointments_AppointmentId",
                table: "_prescriptions");

            migrationBuilder.DropIndex(
                name: "IX__prescriptions_AppointmentId",
                table: "_prescriptions");

            migrationBuilder.DropIndex(
                name: "IX__medicines_PrescriptionId",
                table: "_medicines");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "_prescriptions");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "_medicines");

            migrationBuilder.AddColumn<int>(
                name: "medicineId",
                table: "_prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX__prescriptions_medicineId",
                table: "_prescriptions",
                column: "medicineId");

            migrationBuilder.AddForeignKey(
                name: "FK__prescriptions__medicines_medicineId",
                table: "_prescriptions",
                column: "medicineId",
                principalTable: "_medicines",
                principalColumn: "Id");
        }
    }
}

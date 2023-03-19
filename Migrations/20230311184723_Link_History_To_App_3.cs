using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Link_History_To_App_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__prescriptions__appointments_AppointmentId",
                table: "_prescriptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppointmentId",
                table: "_prescriptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__prescriptions__appointments_AppointmentId",
                table: "_prescriptions",
                column: "AppointmentId",
                principalTable: "_appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__prescriptions__appointments_AppointmentId",
                table: "_prescriptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppointmentId",
                table: "_prescriptions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK__prescriptions__appointments_AppointmentId",
                table: "_prescriptions",
                column: "AppointmentId",
                principalTable: "_appointments",
                principalColumn: "Id");
        }
    }
}

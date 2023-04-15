using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Prescriptioniscollected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isCollected",
                table: "_prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isCollected",
                table: "_prescriptions");
        }
    }
}

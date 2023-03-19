using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPatient = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dose = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__medicines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_pharmacists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pharmacists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_userModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_patientHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doctorInChargeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__patientHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK__patientHistory__doctors_doctorInChargeId",
                        column: x => x.doctorInChargeId,
                        principalTable: "_doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__patientHistory__patients_patientId",
                        column: x => x.patientId,
                        principalTable: "_patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_roleModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK__roleModels__userModels_UserDetailId",
                        column: x => x.UserDetailId,
                        principalTable: "_userModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medicineId = table.Column<int>(type: "int", nullable: true),
                    PatientHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK__prescriptions__medicines_medicineId",
                        column: x => x.medicineId,
                        principalTable: "_medicines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__prescriptions__patientHistory_PatientHistoryId",
                        column: x => x.PatientHistoryId,
                        principalTable: "_patientHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX__patientHistory_doctorInChargeId",
                table: "_patientHistory",
                column: "doctorInChargeId");

            migrationBuilder.CreateIndex(
                name: "IX__patientHistory_patientId",
                table: "_patientHistory",
                column: "patientId");

            migrationBuilder.CreateIndex(
                name: "IX__prescriptions_medicineId",
                table: "_prescriptions",
                column: "medicineId");

            migrationBuilder.CreateIndex(
                name: "IX__prescriptions_PatientHistoryId",
                table: "_prescriptions",
                column: "PatientHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX__roleModels_UserDetailId",
                table: "_roleModels",
                column: "UserDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_appointments");

            migrationBuilder.DropTable(
                name: "_pharmacists");

            migrationBuilder.DropTable(
                name: "_prescriptions");

            migrationBuilder.DropTable(
                name: "_roleModels");

            migrationBuilder.DropTable(
                name: "_medicines");

            migrationBuilder.DropTable(
                name: "_patientHistory");

            migrationBuilder.DropTable(
                name: "_userModels");

            migrationBuilder.DropTable(
                name: "_doctors");

            migrationBuilder.DropTable(
                name: "_patients");
        }
    }
}

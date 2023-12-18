using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class AddTreatmentStrategies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreatmentStrategies",
                columns: table => new
                {
                    TreatmentStrategyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: false),
                    Treatment = table.Column<string>(type: "TEXT", nullable: false),
                    Recomendation = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentStrategies", x => x.TreatmentStrategyId);
                    table.ForeignKey(
                        name: "FK_TreatmentStrategies_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatmentStrategies_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 18, 0, 14, 32, 14, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 1,
                column: "Title",
                value: "���������� �������� ����� �����");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 2,
                column: "Title",
                value: "���������� ��� ���'������� �����������");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 3,
                column: "Title",
                value: "����������� ����������");

            migrationBuilder.InsertData(
                table: "TreatmentStrategies",
                columns: new[] { "TreatmentStrategyId", "Diagnosis", "DoctorId", "PatientId", "Recomendation", "Treatment" },
                values: new object[] { 1, "Cold", 2, 3, "Keep yourself warm", "Drink plenty of teas" });

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStrategies_DoctorId",
                table: "TreatmentStrategies",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatmentStrategies_PatientId",
                table: "TreatmentStrategies",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentStrategies");

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 14, 2, 4, 33, 551, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 1,
                column: "Title",
                value: "Опитування загальної якості життя");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 2,
                column: "Title",
                value: "Опитування про суб'єктивне самопочуття");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 3,
                column: "Title",
                value: "Психологічне опитування");
        }
    }
}

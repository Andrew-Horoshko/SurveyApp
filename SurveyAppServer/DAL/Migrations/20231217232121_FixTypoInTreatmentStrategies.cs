using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class FixTypoInTreatmentStrategies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recomendation",
                table: "TreatmentStrategies",
                newName: "Recommendation");

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 18, 0, 21, 21, 467, DateTimeKind.Local).AddTicks(5920));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Recommendation",
                table: "TreatmentStrategies",
                newName: "Recomendation");

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 18, 0, 14, 32, 14, DateTimeKind.Local).AddTicks(4370));
        }
    }
}

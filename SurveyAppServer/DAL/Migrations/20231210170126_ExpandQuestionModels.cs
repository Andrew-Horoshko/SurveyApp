using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class ExpandQuestionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 10, 18, 1, 26, 115, DateTimeKind.Local).AddTicks(1020));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 10, 15, 35, 59, 700, DateTimeKind.Local).AddTicks(3970));
        }
    }
}

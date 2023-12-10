using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class AddExplicitDiscriminator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "QuestionType",
                value: "SingleChoice");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "QuestionType",
                value: "SingleChoice");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3,
                column: "QuestionType",
                value: "MultipleChoice");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                column: "QuestionType",
                value: "OpenAnswer");

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 10, 15, 35, 59, 700, DateTimeKind.Local).AddTicks(3970));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 7, 0, 14, 18, 49, DateTimeKind.Local).AddTicks(1830));
        }
    }
}

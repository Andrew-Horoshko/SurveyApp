using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class MoveQuestionAnswersProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_MultipleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_SingleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_MultipleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SingleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "MultipleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "SingleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 10, 18, 13, 53, 896, DateTimeKind.Local).AddTicks(4890));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MultipleChoiceQuestionQuestionId",
                table: "Answers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SingleChoiceQuestionQuestionId",
                table: "Answers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 7,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 8,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 9,
                columns: new[] { "MultipleChoiceQuestionQuestionId", "SingleChoiceQuestionQuestionId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 10, 18, 1, 26, 115, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.CreateIndex(
                name: "IX_Answers_MultipleChoiceQuestionQuestionId",
                table: "Answers",
                column: "MultipleChoiceQuestionQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SingleChoiceQuestionQuestionId",
                table: "Answers",
                column: "SingleChoiceQuestionQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_MultipleChoiceQuestionQuestionId",
                table: "Answers",
                column: "MultipleChoiceQuestionQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_SingleChoiceQuestionQuestionId",
                table: "Answers",
                column: "SingleChoiceQuestionQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");
        }
    }
}

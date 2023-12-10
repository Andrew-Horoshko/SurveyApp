using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_AnswerId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "OpenAnswer",
                table: "SurveyAnswers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRightAnswer",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SingleChoiceQuestionQuestionId",
                table: "Answers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyId", "AverageRating", "Title" },
                values: new object[] { 1, 2.3999999999999999, "Mock survey" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "Username" },
                values: new object[] { 1, "admin0@admin.com", "pass123", 0, "admin0" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Discriminator", "HasRightAnswer", "SurveyId", "Text", "Tooltip" },
                values: new object[,]
                {
                    { 1, "SingleChoiceQuestion", true, 1, "How many oceans are there?", "This test aims to asses your memory (1)" },
                    { 2, "SingleChoiceQuestion", true, 1, "How many continents are there?", "This test aims to asses your memory (2)" },
                    { 3, "MultipleChoiceQuestion", false, 1, "When do you feel most hungry?", "This question helps to asses your digestion system's health" },
                    { 4, "OpenTextQuestion", false, 1, "Tell us about your before bed routine", "This question aims to asses the quality of your sleep" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAttempts",
                columns: new[] { "SurveyAttemptId", "AttemptDate", "SurveyId", "UserId" },
                values: new object[] { 1, new DateTime(2023, 12, 7, 0, 14, 18, 49, DateTimeKind.Local).AddTicks(1830), 1, 1 });

            migrationBuilder.InsertData(
                table: "SurveyRatings",
                columns: new[] { "SurveyRatingId", "Mark", "SurveyId", "UserId" },
                values: new object[] { 1, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserManuals",
                columns: new[] { "UserManualId", "Content", "SurveyId", "Title" },
                values: new object[] { 1, "This is a mock survey manual", 1, "Mock survey manual" });

            migrationBuilder.InsertData(
                table: "UserSurveys",
                columns: new[] { "AccessibleByUsersUserId", "AccessibleSurveysSurveyId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "IsCorrect", "MultipleChoiceQuestionQuestionId", "QuestionId", "SingleChoiceQuestionQuestionId", "Text" },
                values: new object[,]
                {
                    { 1, false, null, 1, null, "3" },
                    { 2, true, null, 1, null, "4" },
                    { 3, false, null, 1, null, "5" },
                    { 4, true, null, 2, null, "7" },
                    { 5, false, null, 2, null, "6" },
                    { 6, false, null, 2, null, "5" },
                    { 7, false, null, 3, null, "In the morning" },
                    { 8, false, null, 3, null, "In the afternoon" },
                    { 9, false, null, 3, null, "At night" }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswers",
                columns: new[] { "SurveyAnswerId", "AnswerId", "OpenAnswer", "QuestionId", "SurveyAttemptId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1 },
                    { 2, 6, null, 2, 1 },
                    { 3, 1, "I read a book.", 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SingleChoiceQuestionQuestionId",
                table: "Answers",
                column: "SingleChoiceQuestionQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_SingleChoiceQuestionQuestionId",
                table: "Answers",
                column: "SingleChoiceQuestionQuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_SingleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_SingleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SurveyAnswers",
                keyColumn: "SurveyAnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SurveyRatings",
                keyColumn: "SurveyRatingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserManuals",
                keyColumn: "UserManualId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserSurveys",
                keyColumns: new[] { "AccessibleByUsersUserId", "AccessibleSurveysSurveyId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OpenAnswer",
                table: "SurveyAnswers");

            migrationBuilder.DropColumn(
                name: "HasRightAnswer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "SingleChoiceQuestionQuestionId",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Questions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Questions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_AnswerId",
                table: "Questions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");
        }
    }
}

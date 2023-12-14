using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyAppServer.Migrations
{
    /// <inheritdoc />
    public partial class ExpandSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyId", "AverageRating", "Title" },
                values: new object[,]
                {
                    { 2, 3.6000000000000001, "Опитування про суб'єктивне самопочуття" },
                    { 3, 0.0, "Психологічне опитування" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 2, "isaak@gmail.com", "123456", 1, "Isaak Piterson" },
                    { 3, "ivan@gmail.com", "111111", 2, "Ivan Petryna" },
                    { 4, "vasyl@gmail.com", "111111", 2, "Vasyl Mok" },
                    { 5, "oleg@gmail.com", "111111", 2, "Oleg Birko" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "SurveyAttempts",
                keyColumn: "SurveyAttemptId",
                keyValue: 1,
                column: "AttemptDate",
                value: new DateTime(2023, 12, 10, 18, 13, 53, 896, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "SurveyId",
                keyValue: 1,
                column: "Title",
                value: "Mock survey");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackly.Migrations
{
    /// <inheritdoc />
    public partial class relocationtoHabitReminderInHabitSchudes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitSchedule_Habits_HabitId",
                table: "HabitSchedule");

            migrationBuilder.DropTable(
                name: "Reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitSchedule",
                table: "HabitSchedule");

            migrationBuilder.RenameTable(
                name: "HabitSchedule",
                newName: "HabitSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_HabitSchedule_HabitId",
                table: "HabitSchedules",
                newName: "IX_HabitSchedules_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitSchedules",
                table: "HabitSchedules",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HabitReminder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SchedulesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitReminder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitReminder_HabitSchedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "HabitSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitReminder_SchedulesId",
                table: "HabitReminder",
                column: "SchedulesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitSchedules_Habits_HabitId",
                table: "HabitSchedules",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HabitSchedules_Habits_HabitId",
                table: "HabitSchedules");

            migrationBuilder.DropTable(
                name: "HabitReminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HabitSchedules",
                table: "HabitSchedules");

            migrationBuilder.RenameTable(
                name: "HabitSchedules",
                newName: "HabitSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_HabitSchedules_HabitId",
                table: "HabitSchedule",
                newName: "IX_HabitSchedule_HabitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HabitSchedule",
                table: "HabitSchedule",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reminder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HabitId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_HabitId",
                table: "Reminder",
                column: "HabitId");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitSchedule_Habits_HabitId",
                table: "HabitSchedule",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

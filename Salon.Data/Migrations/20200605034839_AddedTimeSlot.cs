using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Data.Migrations
{
    public partial class AddedTimeSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShifts_TimeSlots_TimeSlotId",
                table: "EmployeeShifts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShifts_TimeSlotId",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "SalonSchedules");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "EmployeeShifts");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "SalonSchedules",
                newName: "TimeSpanId");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "TimeSlots",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalonSchedules_TimeSpanId",
                table: "SalonSchedules",
                column: "TimeSpanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_TimeSpanId",
                table: "EmployeeShifts",
                column: "TimeSpanId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShifts_TimeSlots_TimeSpanId",
                table: "EmployeeShifts",
                column: "TimeSpanId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalonSchedules_TimeSlots_TimeSpanId",
                table: "SalonSchedules",
                column: "TimeSpanId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShifts_TimeSlots_TimeSpanId",
                table: "EmployeeShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_SalonSchedules_TimeSlots_TimeSpanId",
                table: "SalonSchedules");

            migrationBuilder.DropIndex(
                name: "IX_SalonSchedules_TimeSpanId",
                table: "SalonSchedules");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShifts_TimeSpanId",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TimeSlots");

            migrationBuilder.RenameColumn(
                name: "TimeSpanId",
                table: "SalonSchedules",
                newName: "Duration");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "SalonSchedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "EmployeeShifts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShifts_TimeSlotId",
                table: "EmployeeShifts",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeShifts_TimeSlots_TimeSlotId",
                table: "EmployeeShifts",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

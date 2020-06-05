using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Data.Migrations
{
    public partial class RemovedEmployeeSchedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSchedules");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "EmployeeShifts");

            migrationBuilder.AddColumn<int>(
                name: "TimeSlotId",
                table: "EmployeeShifts",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "EmployeeShifts",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "TimeSpanId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeShifts_TimeSlots_TimeSlotId",
                table: "EmployeeShifts");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeShifts_TimeSlotId",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "EmployeeShifts");

            migrationBuilder.DropColumn(
                name: "TimeSpanId",
                table: "EmployeeShifts");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TimeSlots",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "EmployeeShifts",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Start",
                table: "EmployeeShifts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: true),
                    TimeSlotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_TimeSlotId",
                table: "EmployeeSchedules",
                column: "TimeSlotId");
        }
    }
}

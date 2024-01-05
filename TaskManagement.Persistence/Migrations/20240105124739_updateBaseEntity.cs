using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TaskStatuses",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Tasks",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TaskPriorities",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "TaskLevels",
                newName: "CreateUserId");

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "TaskStatuses",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Tasks",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "TaskPriorities",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "TaskLevels",
                newName: "CreatedBy");

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5163));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5322));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5326));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5327));
        }
    }
}

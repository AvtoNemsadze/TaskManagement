using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTimeStamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaskPriorities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "TaskPriorities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaskLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserId",
                table: "TaskLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5147), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5162), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5163), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5304), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5306), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5307), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5308), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5322), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5324), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5325), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5326), "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "LastModifiedUserId" },
                values: new object[] { new DateTime(2024, 1, 5, 16, 13, 38, 500, DateTimeKind.Local).AddTicks(5327), "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskPriorities");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "TaskPriorities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskLevels");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "TaskLevels");

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5686));

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5687));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 17, 20, 25, 29, 445, DateTimeKind.Local).AddTicks(5889));
        }
    }
}

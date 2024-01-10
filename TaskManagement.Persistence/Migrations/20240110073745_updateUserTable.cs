using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastModifiedUserId",
                table: "TaskStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreateUserId",
                table: "TaskStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LastModifiedUserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreateUserId",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LastModifiedUserId",
                table: "TaskPriorities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreateUserId",
                table: "TaskPriorities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LastModifiedUserId",
                table: "TaskLevels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CreateUserId",
                table: "TaskLevels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedUserId",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TaskStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedUserId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedUserId",
                table: "TaskPriorities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TaskPriorities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedUserId",
                table: "TaskLevels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserId",
                table: "TaskLevels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateUserId", "LastModifiedUserId" },
                values: new object[] { "", "" });
        }
    }
}

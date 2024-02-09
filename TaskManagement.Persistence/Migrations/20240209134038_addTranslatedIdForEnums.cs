using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTranslatedIdForEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranslatedId",
                table: "TaskStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranslatedId",
                table: "TaskPriorities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskPriorityEntityId",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskStatusEntityId",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 1,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 2,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 3,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskPriorities",
                keyColumn: "Id",
                keyValue: 4,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskStatuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_TaskPriorityEntityId",
                table: "Contents",
                column: "TaskPriorityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_TaskStatusEntityId",
                table: "Contents",
                column: "TaskStatusEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_TaskPriorities_TaskPriorityEntityId",
                table: "Contents",
                column: "TaskPriorityEntityId",
                principalTable: "TaskPriorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_TaskStatuses_TaskStatusEntityId",
                table: "Contents",
                column: "TaskStatusEntityId",
                principalTable: "TaskStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_TaskPriorities_TaskPriorityEntityId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_TaskStatuses_TaskStatusEntityId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_TaskPriorityEntityId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_TaskStatusEntityId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "TranslatedId",
                table: "TaskStatuses");

            migrationBuilder.DropColumn(
                name: "TranslatedId",
                table: "TaskPriorities");

            migrationBuilder.DropColumn(
                name: "TaskPriorityEntityId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "TaskStatusEntityId",
                table: "Contents");
        }
    }
}

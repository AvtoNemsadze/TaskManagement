using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTranslatedId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranslatedId",
                table: "TaskLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TaskLevelEntityId",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 1,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 2,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TaskLevels",
                keyColumn: "Id",
                keyValue: 3,
                column: "TranslatedId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_TaskLevelEntityId",
                table: "Contents",
                column: "TaskLevelEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_TaskLevels_TaskLevelEntityId",
                table: "Contents",
                column: "TaskLevelEntityId",
                principalTable: "TaskLevels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_TaskLevels_TaskLevelEntityId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_TaskLevelEntityId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "TranslatedId",
                table: "TaskLevels");

            migrationBuilder.DropColumn(
                name: "TaskLevelEntityId",
                table: "Contents");
        }
    }
}

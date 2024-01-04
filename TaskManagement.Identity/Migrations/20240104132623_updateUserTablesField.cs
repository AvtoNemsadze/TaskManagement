using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTablesField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "d62f3ed4-3ce8-4ad5-be1c-ac7b3633e1aa", new DateTime(2024, 1, 4, 17, 26, 23, 7, DateTimeKind.Local).AddTicks(4760), "AQAAAAIAAYagAAAAEMLTSzJk36XuGlZu1xsd7WKkBENdaDB73Z8X+c+4arKJzttv93At2istxO34zjIm6A==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "c39660ee-09f6-485c-9ee5-3e546206b666", new DateTime(2024, 1, 4, 17, 26, 23, 74, DateTimeKind.Local).AddTicks(8069), "AQAAAAIAAYagAAAAEO2qOLzjyBaf3VxJOZo4eR4Xb3p22uukixSBIJZYX1TK9mPQgiXda5Gwl72z+wqdOQ==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "86c2e350-8470-4714-8b54-929270dfbc96", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEHARND3x/AvF+ggaqYwH92TA8RmF8m+II0FEce6Qt4PxT/n9lPZZsKlJx2RpdvCzxg==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "UpdatedAt" },
                values: new object[] { "f517b005-2eee-47a4-be71-793b9b22a800", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEBLa6NFRrddH2BrCQPnfH1vvQXm4+pUIhRZoZZ3NUfAsO6iM/8AmhFlyywh2zwcADw==", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

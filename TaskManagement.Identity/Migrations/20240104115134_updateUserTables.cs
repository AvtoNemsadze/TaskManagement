using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class updateUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "86c2e350-8470-4714-8b54-929270dfbc96", "AQAAAAIAAYagAAAAEHARND3x/AvF+ggaqYwH92TA8RmF8m+II0FEce6Qt4PxT/n9lPZZsKlJx2RpdvCzxg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f517b005-2eee-47a4-be71-793b9b22a800", "AQAAAAIAAYagAAAAEBLa6NFRrddH2BrCQPnfH1vvQXm4+pUIhRZoZZ3NUfAsO6iM/8AmhFlyywh2zwcADw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04bbdc69-3585-43cf-9eff-35548d16f637", "AQAAAAIAAYagAAAAENpAFjIXoOU5CtbKBzYdKkLrXxgrMNOV3rrjFC00MC/37xQhhJO32eQc05Thj9YZRA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72eea8e3-a993-42b0-a3a3-37715579440f", "AQAAAAIAAYagAAAAEOUfFY0LsWvQWRzNzPfbOsQ5pY1C488xkdItVsD/VDnV5O/5nVXzn6rNqY/080L6vA==" });
        }
    }
}

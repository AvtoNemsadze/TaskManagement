using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamMembersEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamMembersEntityId",
                table: "Users",
                column: "TeamMembersEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TeamMembers_TeamMembersEntityId",
                table: "Users",
                column: "TeamMembersEntityId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TeamMembers_TeamMembersEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamMembersEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TeamMembersEntityId",
                table: "Users");
        }
    }
}

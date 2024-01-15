using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adjustPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_TeamMembers_TeamMembersEntityUserId_TeamMembersEntityTeamId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TeamMembersEntityUserId_TeamMembersEntityTeamId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "TeamMembersEntityTeamId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TeamMembersEntityUserId",
                table: "Users",
                newName: "TeamMembersEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamMembersEntityId",
                table: "Users",
                column: "TeamMembersEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers",
                column: "UserId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_UserId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "TeamMembersEntityId",
                table: "Users",
                newName: "TeamMembersEntityUserId");

            migrationBuilder.AddColumn<int>(
                name: "TeamMembersEntityTeamId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                columns: new[] { "UserId", "TeamId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamMembersEntityUserId_TeamMembersEntityTeamId",
                table: "Users",
                columns: new[] { "TeamMembersEntityUserId", "TeamMembersEntityTeamId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TeamMembers_TeamMembersEntityUserId_TeamMembersEntityTeamId",
                table: "Users",
                columns: new[] { "TeamMembersEntityUserId", "TeamMembersEntityTeamId" },
                principalTable: "TeamMembers",
                principalColumns: new[] { "UserId", "TeamId" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateTeamNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamMembersEntityId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DomainUserEntityTeamEntity",
                columns: table => new
                {
                    MemebersId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainUserEntityTeamEntity", x => new { x.MemebersId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_DomainUserEntityTeamEntity_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomainUserEntityTeamEntity_Users_MemebersId",
                        column: x => x.MemebersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamMembersEntityId",
                table: "Teams",
                column: "TeamMembersEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainUserEntityTeamEntity_TeamsId",
                table: "DomainUserEntityTeamEntity",
                column: "TeamsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamMembers_TeamMembersEntityId",
                table: "Teams",
                column: "TeamMembersEntityId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamMembers_TeamMembersEntityId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "DomainUserEntityTeamEntity");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamMembersEntityId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamMembersEntityId",
                table: "Teams");
        }
    }
}

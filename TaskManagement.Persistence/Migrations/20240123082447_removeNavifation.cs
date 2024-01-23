using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeNavifation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamMembers_TeamMembersEntityId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeamMembersEntityId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamMembersEntityId",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamMembersEntityId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamMembersEntityId",
                table: "Teams",
                column: "TeamMembersEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamMembers_TeamMembersEntityId",
                table: "Teams",
                column: "TeamMembersEntityId",
                principalTable: "TeamMembers",
                principalColumn: "Id");
        }
    }
}

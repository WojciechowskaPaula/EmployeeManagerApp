using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Migrations
{
    public partial class ChangeRelationshipBetweenJobHistoryAndPositionAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Positions_PositionId",
                table: "JobHistories");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_PositionId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "JobHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "JobHistoryPosition",
                columns: table => new
                {
                    JobHistoryId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistoryPosition", x => new { x.JobHistoryId, x.PositionId });
                    table.ForeignKey(
                        name: "FK_JobHistoryPosition_JobHistories_JobHistoryId",
                        column: x => x.JobHistoryId,
                        principalTable: "JobHistories",
                        principalColumn: "JobHistoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobHistoryPosition_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_PositionId",
                table: "JobHistories",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistoryPosition_PositionId",
                table: "JobHistoryPosition",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Positions_PositionId",
                table: "JobHistories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobHistories_Positions_PositionId",
                table: "JobHistories");

            migrationBuilder.DropTable(
                name: "JobHistoryPosition");

            migrationBuilder.DropIndex(
                name: "IX_JobHistories_PositionId",
                table: "JobHistories");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "JobHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobHistories_PositionId",
                table: "JobHistories",
                column: "PositionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobHistories_Positions_PositionId",
                table: "JobHistories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSoftware.Data.Migrations
{
    public partial class InvalidColumnAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitities_Remarks_Activitity",
                table: "Activitities");

            migrationBuilder.DropIndex(
                name: "IX_Activitities_Activitity",
                table: "Activitities");

            migrationBuilder.DropColumn(
                name: "Activitity",
                table: "Activitities");

            migrationBuilder.AddColumn<int>(
                name: "ActivitityId",
                table: "Remarks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Activitities_RemarkId",
                table: "Activitities",
                column: "RemarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitities_Remarks_RemarkId",
                table: "Activitities",
                column: "RemarkId",
                principalTable: "Remarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitities_Remarks_RemarkId",
                table: "Activitities");

            migrationBuilder.DropIndex(
                name: "IX_Activitities_RemarkId",
                table: "Activitities");

            migrationBuilder.DropColumn(
                name: "ActivitityId",
                table: "Remarks");

            migrationBuilder.AddColumn<int>(
                name: "Activitity",
                table: "Activitities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activitities_Activitity",
                table: "Activitities",
                column: "Activitity");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitities_Remarks_Activitity",
                table: "Activitities",
                column: "Activitity",
                principalTable: "Remarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

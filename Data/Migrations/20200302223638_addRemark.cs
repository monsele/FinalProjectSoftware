using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSoftware.Data.Migrations
{
    public partial class addRemark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Activitities");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RemarkId",
                table: "Activitities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Remarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remarks", x => x.Id);
                });

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitities_Remarks_RemarkId",
                table: "Activitities");

            migrationBuilder.DropTable(
                name: "Remarks");

            migrationBuilder.DropIndex(
                name: "IX_Activitities_RemarkId",
                table: "Activitities");

            migrationBuilder.DropColumn(
                name: "RemarkId",
                table: "Activitities");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Activitities",
                nullable: true);
        }
    }
}

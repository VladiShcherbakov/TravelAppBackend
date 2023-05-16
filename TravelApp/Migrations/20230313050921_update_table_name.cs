using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp.Migrations
{
    public partial class update_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelInfoModel_TravelPlans_PlanModelId",
                table: "TravelInfoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelInfoModel",
                table: "TravelInfoModel");

            migrationBuilder.RenameTable(
                name: "TravelInfoModel",
                newName: "TravelInfos");

            migrationBuilder.RenameIndex(
                name: "IX_TravelInfoModel_PlanModelId",
                table: "TravelInfos",
                newName: "IX_TravelInfos_PlanModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelInfos",
                table: "TravelInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelInfos_TravelPlans_PlanModelId",
                table: "TravelInfos",
                column: "PlanModelId",
                principalTable: "TravelPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelInfos_TravelPlans_PlanModelId",
                table: "TravelInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelInfos",
                table: "TravelInfos");

            migrationBuilder.RenameTable(
                name: "TravelInfos",
                newName: "TravelInfoModel");

            migrationBuilder.RenameIndex(
                name: "IX_TravelInfos_PlanModelId",
                table: "TravelInfoModel",
                newName: "IX_TravelInfoModel_PlanModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelInfoModel",
                table: "TravelInfoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelInfoModel_TravelPlans_PlanModelId",
                table: "TravelInfoModel",
                column: "PlanModelId",
                principalTable: "TravelPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticCompany.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tranports_TranportId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TranportId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TranportId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransportId",
                table: "Orders",
                column: "TransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tranports_TransportId",
                table: "Orders",
                column: "TransportId",
                principalTable: "Tranports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tranports_TransportId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TransportId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "TranportId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TranportId",
                table: "Orders",
                column: "TranportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tranports_TranportId",
                table: "Orders",
                column: "TranportId",
                principalTable: "Tranports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

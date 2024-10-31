using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticCompany.Migrations
{
    public partial class morefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tranports_TransportId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tranports",
                table: "Tranports");

            migrationBuilder.RenameTable(
                name: "Tranports",
                newName: "Transports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transports",
                table: "Transports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Transports_TransportId",
                table: "Orders",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Transports_TransportId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transports",
                table: "Transports");

            migrationBuilder.RenameTable(
                name: "Transports",
                newName: "Tranports");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tranports",
                table: "Tranports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tranports_TransportId",
                table: "Orders",
                column: "TransportId",
                principalTable: "Tranports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

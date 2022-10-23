using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureSample.Infrastructure.Migrations
{
    public partial class ChangeCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackingItems_PackingLists_PackingListId",
                schema: "packing",
                table: "PackingItems");

            migrationBuilder.AddForeignKey(
                name: "FK_PackingItems_PackingLists_PackingListId",
                schema: "packing",
                table: "PackingItems",
                column: "PackingListId",
                principalSchema: "packing",
                principalTable: "PackingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackingItems_PackingLists_PackingListId",
                schema: "packing",
                table: "PackingItems");

            migrationBuilder.AddForeignKey(
                name: "FK_PackingItems_PackingLists_PackingListId",
                schema: "packing",
                table: "PackingItems",
                column: "PackingListId",
                principalSchema: "packing",
                principalTable: "PackingLists",
                principalColumn: "Id");
        }
    }
}

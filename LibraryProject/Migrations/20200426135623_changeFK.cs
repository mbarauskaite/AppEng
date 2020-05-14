using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class changeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tobook",
                schema: "lib",
                table: "copy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                schema: "lib",
                table: "book");

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                schema: "lib",
                table: "book",
                type: "character(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(13)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                schema: "lib",
                table: "book",
                column: "isbn");

            migrationBuilder.CreateIndex(
                name: "IX_copy_isbn",
                schema: "lib",
                table: "copy",
                column: "isbn");

            migrationBuilder.AddForeignKey(
                name: "tobook",
                schema: "lib",
                table: "copy",
                column: "isbn",
                principalSchema: "lib",
                principalTable: "book",
                principalColumn: "isbn",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "tobook",
                schema: "lib",
                table: "copy");

            migrationBuilder.DropIndex(
                name: "IX_copy_isbn",
                schema: "lib",
                table: "copy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                schema: "lib",
                table: "book");

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                schema: "lib",
                table: "book",
                type: "character(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character(13)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                schema: "lib",
                table: "book",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "tobook",
                schema: "lib",
                table: "copy",
                column: "Id",
                principalSchema: "lib",
                principalTable: "book",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

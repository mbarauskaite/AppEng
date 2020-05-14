using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.Migrations
{
    public partial class AddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lib");

            migrationBuilder.CreateTable(
                name: "book",
                schema: "lib",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    isbn = table.Column<string>(type: "character(13)", nullable: true),
                    author = table.Column<string>(type: "character varying(30)", nullable: false),
                    title = table.Column<string>(type: "character varying(50)", nullable: false),
                    date = table.Column<short>(nullable: false),
                    publisher = table.Column<string>(type: "character varying(20)", nullable: false),
                    genre = table.Column<string>(type: "character varying(20)", nullable: false),
                    pages = table.Column<short>(nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "lib",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    identitycode = table.Column<string>(type: "character(11)", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", nullable: false),
                    password = table.Column<string>(nullable: false),
                    role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "copy",
                schema: "lib",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    isbn = table.Column<string>(type: "character(13)", nullable: false),
                    libuser = table.Column<int>(nullable: true),
                    taken = table.Column<DateTime>(type: "date", nullable: true),
                    @return = table.Column<DateTime>(name: "return", type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_copy", x => x.Id);
                    table.ForeignKey(
                        name: "tobook",
                        column: x => x.Id,
                        principalSchema: "lib",
                        principalTable: "book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "touser",
                        column: x => x.libuser,
                        principalSchema: "lib",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_copy_libuser",
                schema: "lib",
                table: "copy",
                column: "libuser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "copy",
                schema: "lib");

            migrationBuilder.DropTable(
                name: "book",
                schema: "lib");

            migrationBuilder.DropTable(
                name: "user",
                schema: "lib");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class Owners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearsSubscribed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_OwnerId",
                table: "Blog",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_OwnerId1",
                table: "Blog",
                column: "OwnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Owners_OwnerId",
                table: "Blog",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Owners_OwnerId1",
                table: "Blog",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Owners_OwnerId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Owners_OwnerId1",
                table: "Blog");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Blog_OwnerId",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_OwnerId1",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Blog");
        }
    }
}

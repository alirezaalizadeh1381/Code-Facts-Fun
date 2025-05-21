using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addForeignKeyForClipProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClipsId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClipsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClipsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClipsId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClipsId",
                table: "Products",
                column: "ClipsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Movies_ClipsId",
                table: "Products",
                column: "ClipsId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Movies_ClipsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ClipsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClipsId",
                table: "Products");
        }
    }
}

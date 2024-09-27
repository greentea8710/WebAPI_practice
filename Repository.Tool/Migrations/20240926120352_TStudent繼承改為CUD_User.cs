using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class TStudent繼承改為CUD_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreateUserId",
                table: "Student",
                type: "bigint",
                nullable: true,
                comment: "创建人ID");

            migrationBuilder.AddColumn<long>(
                name: "DeleteUserId",
                table: "Student",
                type: "bigint",
                nullable: true,
                comment: "删除人ID");

            migrationBuilder.AddColumn<long>(
                name: "UpdateUserId",
                table: "Student",
                type: "bigint",
                nullable: true,
                comment: "编辑人ID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreateUserId",
                table: "Student",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeleteUserId",
                table: "Student",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UpdateUserId",
                table: "Student",
                column: "UpdateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_CreateUserId",
                table: "Student",
                column: "CreateUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_DeleteUserId",
                table: "Student",
                column: "DeleteUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UpdateUserId",
                table: "Student",
                column: "UpdateUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_CreateUserId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_DeleteUserId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UpdateUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CreateUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_DeleteUserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_UpdateUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Student");
        }
    }
}

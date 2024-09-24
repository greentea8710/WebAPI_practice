using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class Tcourse更改繼承為CUD_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Course",
                comment: "班級信息表",
                oldComment: "角色信息表");

            migrationBuilder.AddColumn<long>(
                name: "CreateUserId",
                table: "Course",
                type: "bigint",
                nullable: true,
                comment: "创建人ID");

            migrationBuilder.AddColumn<long>(
                name: "DeleteUserId",
                table: "Course",
                type: "bigint",
                nullable: true,
                comment: "删除人ID");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdateTime",
                table: "Course",
                type: "timestamp with time zone",
                nullable: true,
                comment: "更新时间");

            migrationBuilder.AddColumn<long>(
                name: "UpdateUserId",
                table: "Course",
                type: "bigint",
                nullable: true,
                comment: "编辑人ID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CreateUserId",
                table: "Course",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DeleteUserId",
                table: "Course",
                column: "DeleteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UpdateTime",
                table: "Course",
                column: "UpdateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Course_UpdateUserId",
                table: "Course",
                column: "UpdateUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_CreateUserId",
                table: "Course",
                column: "CreateUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_DeleteUserId",
                table: "Course",
                column: "DeleteUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_User_UpdateUserId",
                table: "Course",
                column: "UpdateUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_CreateUserId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_DeleteUserId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_User_UpdateUserId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CreateUserId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_DeleteUserId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_UpdateTime",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_UpdateUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DeleteUserId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "UpdateUserId",
                table: "Course");

            migrationBuilder.AlterTable(
                name: "Course",
                comment: "角色信息表",
                oldComment: "班級信息表");
        }
    }
}

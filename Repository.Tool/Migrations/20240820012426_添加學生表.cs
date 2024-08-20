using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 添加學生表 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "姓名"),
                    Number = table.Column<string>(type: "text", nullable: false, comment: "學號"),
                    Gender = table.Column<int>(type: "integer", nullable: false, comment: "性別"),
                    Phone = table.Column<string>(type: "text", nullable: false, comment: "電話"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记"),
                    UpdateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                },
                comment: "學生表");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CreateTime",
                table: "Student",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Student_DeleteTime",
                table: "Student",
                column: "DeleteTime");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UpdateTime",
                table: "Student",
                column: "UpdateTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}

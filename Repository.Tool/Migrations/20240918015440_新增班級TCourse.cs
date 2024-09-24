using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 新增班級TCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "主键标识ID"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "角色名称"),
                    StudentTotal = table.Column<string>(type: "text", nullable: false, comment: "StudentTotal"),
                    MaleStudentTotal = table.Column<string>(type: "text", nullable: false, comment: "MaleStudentTotal"),
                    FemaleStudentTotal = table.Column<string>(type: "text", nullable: false, comment: "FemaleStudentTotal"),
                    Grade = table.Column<string>(type: "text", nullable: false, comment: "Grade"),
                    Url = table.Column<string>(type: "text", nullable: false, comment: "Url"),
                    CreateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "创建时间"),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, comment: "是否删除"),
                    DeleteTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "删除时间"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false, comment: "行版本标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                },
                comment: "角色信息表");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CreateTime",
                table: "Course",
                column: "CreateTime");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DeleteTime",
                table: "Course",
                column: "DeleteTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}

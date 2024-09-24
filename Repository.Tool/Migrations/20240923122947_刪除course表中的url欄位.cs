using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 刪除course表中的url欄位 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "StudentTotal",
                table: "Course",
                type: "integer",
                nullable: false,
                comment: "學生總數",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "StudentTotal");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "班級名称",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "角色名称");

            migrationBuilder.AlterColumn<int>(
                name: "MaleStudentTotal",
                table: "Course",
                type: "integer",
                nullable: false,
                comment: "男性人數",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "MaleStudentTotal");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "年級",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Grade");

            migrationBuilder.AlterColumn<int>(
                name: "FemaleStudentTotal",
                table: "Course",
                type: "integer",
                nullable: false,
                comment: "女性人數",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "FemaleStudentTotal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentTotal",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "StudentTotal",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "學生總數");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "角色名称",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "班級名称");

            migrationBuilder.AlterColumn<string>(
                name: "MaleStudentTotal",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "MaleStudentTotal",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "男性人數");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "Grade",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "年級");

            migrationBuilder.AlterColumn<string>(
                name: "FemaleStudentTotal",
                table: "Course",
                type: "text",
                nullable: false,
                comment: "FemaleStudentTotal",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "女性人數");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Course",
                type: "text",
                nullable: true,
                comment: "Url");
        }
    }
}

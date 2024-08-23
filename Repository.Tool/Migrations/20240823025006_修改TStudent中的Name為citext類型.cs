using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 修改TStudent中的Name為citext類型 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Student",
                type: "citext",
                nullable: false,
                comment: "姓名",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "姓名");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Student",
                type: "text",
                nullable: false,
                comment: "姓名",
                oldClrType: typeof(string),
                oldType: "citext",
                oldComment: "姓名");
        }
    }
}

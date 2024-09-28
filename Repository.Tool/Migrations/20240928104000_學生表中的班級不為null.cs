using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 學生表中的班級不為null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Student",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "CourseId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "Student",
                type: "bigint",
                nullable: true,
                comment: "CourseId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "CourseId");
        }
    }
}

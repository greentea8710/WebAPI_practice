using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class 調整學生表資料classid不可為null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ClassId",
                table: "Student",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "ClassId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ClassId",
                table: "Student",
                type: "bigint",
                nullable: true,
                comment: "ClassId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "ClassId");
        }
    }
}

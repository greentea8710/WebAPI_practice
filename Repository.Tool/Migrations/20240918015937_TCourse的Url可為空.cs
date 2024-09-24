using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Tool.Migrations
{
    /// <inheritdoc />
    public partial class TCourse的Url可為空 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Course",
                type: "text",
                nullable: true,
                comment: "Url",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Course",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Url",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Url");
        }
    }
}

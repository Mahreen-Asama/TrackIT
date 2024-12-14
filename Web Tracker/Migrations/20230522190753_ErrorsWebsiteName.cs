using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class ErrorsWebsiteName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebsiteName",
                table: "ErrorDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebsiteName",
                table: "ErrorDatas");
        }
    }
}

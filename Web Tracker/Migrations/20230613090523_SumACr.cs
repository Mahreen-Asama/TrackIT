using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class SumACr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"CREATE VIEW [dbo].[ActionCollectSum]
	AS SELECT [From-Content] as ""From-Content"", [To-Content] as ""To-Content"", [From-Type] as ""From-Type"", [To-Type] as ""To-Type"", Count(*) as ""Count"", [WebsiteId] as ""WebsiteId"", [Page] as ""Page""
	FROM [ActionCollect]
	Group by [To-Content],[To-Type], [From-Content], [From-Type], [Page], [WebsiteId]
"
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

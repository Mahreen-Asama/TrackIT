using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class NewActionCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
               @"CREATE VIEW [dbo].[ActionCollect]
	AS SELECT F1.[Type] as ""From-Type"", F2.[Type] as ""To-Type"",F1.[Content] as ""From-Content"", F2.[Content] as ""To-Content"", F1.FlowId as ""FlowID"", US.WebsiteId as ""WebsiteId"", F1.[Page] as ""Page""
	FROM [Actions] F1
	JOIN [Actions] F2 ON F1.[ActionId] = F2.[ActionId] - 1
	JOIN [Flows] FW ON F1.FlowId = FW.FlowId
	JOIN [Users] US ON FW.UserId = US.UserId
	Where F1.FlowId=F2.FlowId AND F1.[Page]=F2.[Page]
"
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

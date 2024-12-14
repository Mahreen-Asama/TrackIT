using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRCheck.Migrations
{
    /// <inheritdoc />
    public partial class ViewMaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[SummedFlow]
	AS SELECT FD.[FlowId], US.WebsiteId, STRING_AGG(CONCAT(FD.[Page],''),'>') AS [Flowsummed]
	FROM [FlowDatas] AS FD 
	Inner Join [Flows] AS FS
	ON FD.FlowId=FS.FlowId
	Inner Join [Users] AS US
	ON US.UserId=FS.UserId
	Group by FD.FlowId, US.WebsiteId");
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[SummedAction]
	AS SELECT AC.[FlowId], US.WebsiteId, CONCAT(AC.[Page],'[',STRING_AGG(CONCAT(AC.[Type],'(', AC.Content, ')'),'>'), ']') AS [Flowsummed]
	FROM [Actions] AS AC 
	Inner Join [Flows] AS FS
	ON AC.FlowId=FS.FlowId
	Inner Join [Users] AS US
	ON US.UserId=FS.UserId
	Group by US.WebsiteId, AC.FlowId, Ac.Page");
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[SummaryTable]
	AS SELECT [Flowsummed], [WebsiteId], COUNT([Flowsummed]) AS Count FROM [SummedFlow]
	Group by Flowsummed, WebsiteId");
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[ActionSummaryTable]
	AS SELECT [Flowsummed], [WebsiteId], COUNT([Flowsummed]) AS Count FROM [SummedAction]
	Group by Flowsummed, WebsiteId");
            migrationBuilder.Sql(
                @"CREATE VIEW [dbo].[FlowCollect]
	AS SELECT F1.[Page] as ""To"", F2.[Page] as ""From"", F1.FlowId as ""FlowID""
	FROM [FlowDatas] F1
	JOIN [FlowDatas] F2 ON F1.[FlowDataId] = F2.[FlowDataId] - 1
	Where F1.FlowId=F2.FlowId
"
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

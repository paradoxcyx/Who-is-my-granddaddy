using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoIsMyGranddaddy.Data.Migrations
{
    public partial class AddDescendantsByPersonIdSpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"CREATE PROCEDURE [site].[GetDescendantsByIdentityNumber]
                    @IdentityNumber NVARCHAR(MAX) = NULL,
                    @PageSize INT = 10,
                    @PageNumber INT = 1,
                    @MaxPages INT OUTPUT
                AS
                BEGIN
                    CREATE TABLE #TempRecursiveDescendants (
	                RowNum INT,
                        Id INT,
                        FatherId INT,
                        MotherId INT,
                        Name NVARCHAR(MAX),
                        Surname NVARCHAR(MAX),
                        BirthDate DATE,
                        IdentityNumber NVARCHAR(MAX),
		                PartnerId INT
                    );

                ;WITH RecursiveDescendants AS (
                    SELECT
                        Id,
                        FatherId,
                        MotherId,
                        Name,
                        Surname,
                        BirthDate,
                        IdentityNumber,
                        1 AS RowNum
                    FROM
                        [site].[Persons]
                    WHERE
                        @IdentityNumber IS NULL OR IdentityNumber = @IdentityNumber
                    UNION ALL
                    SELECT
                        p.Id,
                        p.FatherId,
                        p.MotherId,
                        p.Name,
                        p.Surname,
                        p.BirthDate,
                        p.IdentityNumber,
                        rd.RowNum + 1
                    FROM
                        [site].[Persons] p
                    INNER JOIN
                        RecursiveDescendants rd ON rd.Id = p.FatherId OR rd.Id = p.MotherId
                )

                    INSERT INTO #TempRecursiveDescendants (Id, FatherId, MotherId, Name, Surname, BirthDate, IdentityNumber, PartnerId)
                    SELECT 
                        rd.Id,
                        CASE WHEN (@IdentityNumber IS NOT NULL AND rd.RowNum = 1 AND @PageNumber = 1) THEN NULL ELSE rd.FatherId END AS FatherId,
                        CASE WHEN (@IdentityNumber IS NOT NULL AND rd.RowNum = 1 AND @PageNumber = 1) THEN NULL ELSE rd.MotherId END AS MotherId,
                        rd.Name,
                        rd.Surname,
                        rd.BirthDate,
                        rd.IdentityNumber,
                        COALESCE(
                            CASE WHEN m.MotherId = rd.Id THEN m.FatherId END,
                            CASE WHEN f.FatherId = rd.Id THEN f.MotherId END
                        ) AS PartnerId
                    FROM 
                        RecursiveDescendants rd
                    LEFT JOIN 
                        [site].[Persons] m ON m.MotherId = rd.Id
	                LEFT JOIN 
                        [site].[Persons] f ON f.FatherId = rd.Id;

                    -- Calculate Max Pages
                    SELECT @MaxPages = CEILING(COUNT(DISTINCT(Id)) / CAST(@PageSize AS FLOAT))
                    FROM #TempRecursiveDescendants
                    WHERE @IdentityNumber IS NULL OR 1 = 1;

                    -- Fetch Paged Results
                    SELECT
		                DISTINCT(Id),
		                RowNum,
                        FatherId,
                        MotherId,
                        Name,
                        Surname,
                        BirthDate,
                        IdentityNumber,
		                PartnerId
                    FROM
                        #TempRecursiveDescendants
                    WHERE @IdentityNumber IS NULL OR 1 = 1
                    ORDER BY Id
                    OFFSET (@PageNumber - 1) * @PageSize ROWS
                    FETCH NEXT @PageSize ROWS ONLY;

                    -- Drop temporary table
                    DROP TABLE #TempRecursiveDescendants;
                END

			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP PROCEDURE [site].[GetDescendantsByPersonId]");
        }
    }
}

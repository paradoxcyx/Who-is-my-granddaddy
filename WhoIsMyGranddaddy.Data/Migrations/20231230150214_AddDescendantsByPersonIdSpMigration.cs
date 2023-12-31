using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoIsMyGranddaddy.Data.Migrations
{
    public partial class AddDescendantsByPersonIdSpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"CREATE PROCEDURE [site].[GetDescendantsByIdentityNumber]
					@IdentityNumber NVARCHAR(MAX)
					AS
					BEGIN
						WITH RecursiveDescendants AS (
						SELECT
							Id,
							FatherId,
							MotherId,
							Name,
							Surname,
							BirthDate,
							IdentityNumber
						FROM
							[site].[Persons]
						WHERE
							IdentityNumber = @IdentityNumber
						UNION ALL
						SELECT
							p.Id,
							p.FatherId,
							p.MotherId,
							p.Name,
							p.Surname,
							p.BirthDate,
							p.IdentityNumber
						FROM
							[site].[Persons] p
						INNER JOIN
							RecursiveDescendants rd ON rd.Id = p.FatherId OR rd.Id = p.MotherId
						)
						SELECT
							DISTINCT(Id)
							Id,
							FatherId,
							MotherId,
							Name,
							Surname,
							BirthDate,
							IdentityNumber
						FROM
							RecursiveDescendants WHERE IdentityNumber != @IdentityNumber
						ORDER BY BirthDate ASC;
				END
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP PROCEDURE [site].[GetDescendantsByPersonId]");
        }
    }
}

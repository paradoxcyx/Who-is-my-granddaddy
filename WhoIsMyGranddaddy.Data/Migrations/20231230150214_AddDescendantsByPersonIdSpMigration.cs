using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoIsMyGranddaddy.Data.Migrations
{
    public partial class AddDescendantsByPersonIdSpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"CREATE PROCEDURE [site].[GetDescendantsByIdentityNumber]
					@IdentityNumber NVARCHAR(MAX) NULL
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
							@IdentityNumber IS NULL OR IdentityNumber = @IdentityNumber
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
							RecursiveDescendants WHERE @IdentityNumber IS NULL OR 1 = 1
				END
			");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP PROCEDURE [site].[GetDescendantsByPersonId]");
        }
    }
}

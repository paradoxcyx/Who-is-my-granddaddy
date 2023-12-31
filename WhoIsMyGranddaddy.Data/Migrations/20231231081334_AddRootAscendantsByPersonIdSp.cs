using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoIsMyGranddaddy.Data.Migrations
{
    public partial class AddRootAscendantsByPersonIdSp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [site].[GetRootAscendantsByIdentityNumber]
                    @IdentityNumber NVARCHAR(MAX)
                AS
                BEGIN
                    WITH RecursiveAscendants AS (
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
                            RecursiveAscendants ra ON ra.FatherId = p.Id OR ra.MotherId = p.Id
                    )
                    SELECT
                        DISTINCT Id,
                        FatherId,
                        MotherId,
                        Name,
                        Surname,
                        BirthDate,
                        IdentityNumber
                    FROM
                        RecursiveAscendants
                    WHERE
                        (FatherId IS NULL OR MotherId IS NULL)
                    ORDER BY
                        BirthDate ASC;
                END
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [site].[GetRootAscendantsByIdentityNumber]");
        }
    }
}

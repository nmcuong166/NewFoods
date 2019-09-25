using Microsoft.EntityFrameworkCore.Migrations;

namespace NewFood.Infurstructure.Migrations
{
    public partial class sp_GetNewById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storeProcedure = @"CREATE PROCEDURE sp_GetNewById
                                   @id INT,
                                   @contents NVARCHAR(50)
                                   AS
                                   BEGIN 
	                                    IF @id > 0 OR @contents != ''
		                                    SELECT * FROM News n
		                                    WHERE n.Id = @id OR N.Contens Like '%' + @contents + '%'
	                                    ELSE
		                                    SELECT n.Id, n.IsDeleted, n.Contens
		                                    FROM News n
		                                    ORDER BY n.Id
                                   END";
            migrationBuilder.Sql(storeProcedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

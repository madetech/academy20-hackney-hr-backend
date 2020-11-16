using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    job_title = table.Column<string>(type: "text", nullable: false),
                    contact_email = table.Column<string>(type: "text", nullable: false),
                    contact_number = table.Column<long>(type: "bigint", nullable: false),
                    salary_band = table.Column<string>(type: "text", nullable: false),
                    home_address_line_1 = table.Column<string>(type: "text", nullable: false),
                    home_address_line_2 = table.Column<string>(type: "text", nullable: true),
                    home_address_city = table.Column<string>(type: "text", nullable: false),
                    home_address_postcode = table.Column<string>(type: "text", nullable: false),
                    office_location = table.Column<string>(type: "text", nullable: false),
                    manager = table.Column<string>(type: "text", nullable: true),
                    reportees = table.Column<string>(type: "text", nullable: true),
                    next_of_kin_first_name = table.Column<string>(type: "text", nullable: false),
                    next_of_kin_last_name = table.Column<string>(type: "text", nullable: false),
                    next_of_kin_contact_number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

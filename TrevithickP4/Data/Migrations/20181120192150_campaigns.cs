using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrevithickP4.Data.Migrations
{
    public partial class campaigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vendor = table.Column<string>(nullable: true),
                    Candidate = table.Column<string>(nullable: true),
                    Contributor = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    Datetime = table.Column<string>(nullable: true),
                    Contribution = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaigns", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "campaigns");
        }
    }
}

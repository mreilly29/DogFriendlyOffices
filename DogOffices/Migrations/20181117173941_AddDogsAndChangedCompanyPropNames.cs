using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogOffices.Migrations
{
    public partial class AddDogsAndChangedCompanyPropNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Companies",
                newName: "CompanyZipCode");

            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "Companies",
                newName: "CompanyWebsiteUrl");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Companies",
                newName: "CompanyState");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Companies",
                newName: "CompanyDescription");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Companies",
                newName: "CompanyCity");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Companies",
                newName: "CompanyAddress");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Companies",
                newName: "CompanyId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyDogId",
                table: "Companies",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DogName = table.Column<string>(nullable: true),
                    DogBreed = table.Column<string>(nullable: true),
                    DogDescription = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dogs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_CompanyId",
                table: "Dogs",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropColumn(
                name: "CompanyDogId",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "CompanyZipCode",
                table: "Companies",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "CompanyWebsiteUrl",
                table: "Companies",
                newName: "WebsiteUrl");

            migrationBuilder.RenameColumn(
                name: "CompanyState",
                table: "Companies",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "CompanyDescription",
                table: "Companies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CompanyCity",
                table: "Companies",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "CompanyAddress",
                table: "Companies",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "Id");
        }
    }
}

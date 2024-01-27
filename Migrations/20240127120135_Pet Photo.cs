using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopt_Pet.Api.Migrations
{
    /// <inheritdoc />
    public partial class PetPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "petModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "petModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

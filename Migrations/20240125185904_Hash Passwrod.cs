using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopt_Pet.Api.Migrations
{
    /// <inheritdoc />
    public partial class HashPasswrod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "petModels");

            migrationBuilder.RenameColumn(
                name: "Repassword",
                table: "petModels",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "petModels",
                newName: "Repassword");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "petModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

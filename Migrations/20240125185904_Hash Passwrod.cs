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
                table: "abrigoModels");

            migrationBuilder.RenameColumn(
                name: "Repassword",
                table: "abrigoModels",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "abrigoModels",
                newName: "Repassword");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "abrigoModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopt_Pet.Api.Migrations
{
    /// <inheritdoc />
    public partial class PetsandAbrigo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "petModels");

            migrationBuilder.DropColumn(
                name: "City",
                table: "petModels");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "petModels",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "petModels",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "petModels",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "petModels",
                newName: "age");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "petModels",
                newName: "address");

            migrationBuilder.AddColumn<int>(
                name: "Abrigo_id",
                table: "petModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "adopted",
                table: "petModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AbrigoModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    CNPJ = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbrigoModel", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_petModels_Abrigo_id",
                table: "petModels",
                column: "Abrigo_id");

            migrationBuilder.AddForeignKey(
                name: "FK_petModels_AbrigoModel_Abrigo_id",
                table: "petModels",
                column: "Abrigo_id",
                principalTable: "AbrigoModel",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_petModels_AbrigoModel_Abrigo_id",
                table: "petModels");

            migrationBuilder.DropTable(
                name: "AbrigoModel");

            migrationBuilder.DropIndex(
                name: "IX_petModels_Abrigo_id",
                table: "petModels");

            migrationBuilder.DropColumn(
                name: "Abrigo_id",
                table: "petModels");

            migrationBuilder.DropColumn(
                name: "adopted",
                table: "petModels");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "petModels",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "petModels",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "petModels",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "petModels",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "petModels",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "petModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "petModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

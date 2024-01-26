using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Adopt_Pet.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdocaoandPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdocaoModel_AspNetUsers_TutorModelId",
                table: "AdocaoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AdocaoModel_petModels_PetModelid",
                table: "AdocaoModel");

            migrationBuilder.DropIndex(
                name: "IX_AdocaoModel_PetModelid",
                table: "AdocaoModel");

            migrationBuilder.DropIndex(
                name: "IX_AdocaoModel_TutorModelId",
                table: "AdocaoModel");

            migrationBuilder.DropColumn(
                name: "PetModelid",
                table: "AdocaoModel");

            migrationBuilder.DropColumn(
                name: "TutorModelId",
                table: "AdocaoModel");

            migrationBuilder.CreateIndex(
                name: "IX_AdocaoModel_pet_id",
                table: "AdocaoModel",
                column: "pet_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdocaoModel_tutor_id",
                table: "AdocaoModel",
                column: "tutor_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdocaoModel_AspNetUsers_tutor_id",
                table: "AdocaoModel",
                column: "tutor_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdocaoModel_petModels_pet_id",
                table: "AdocaoModel",
                column: "pet_id",
                principalTable: "petModels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdocaoModel_AspNetUsers_tutor_id",
                table: "AdocaoModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AdocaoModel_petModels_pet_id",
                table: "AdocaoModel");

            migrationBuilder.DropIndex(
                name: "IX_AdocaoModel_pet_id",
                table: "AdocaoModel");

            migrationBuilder.DropIndex(
                name: "IX_AdocaoModel_tutor_id",
                table: "AdocaoModel");

            migrationBuilder.AddColumn<int>(
                name: "PetModelid",
                table: "AdocaoModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TutorModelId",
                table: "AdocaoModel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdocaoModel_PetModelid",
                table: "AdocaoModel",
                column: "PetModelid");

            migrationBuilder.CreateIndex(
                name: "IX_AdocaoModel_TutorModelId",
                table: "AdocaoModel",
                column: "TutorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdocaoModel_AspNetUsers_TutorModelId",
                table: "AdocaoModel",
                column: "TutorModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdocaoModel_petModels_PetModelid",
                table: "AdocaoModel",
                column: "PetModelid",
                principalTable: "petModels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iRecipeAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class smallfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecepies_Recepies_RecipeId",
                table: "IngredientRecepies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecipeDate",
                table: "Recepies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "IngredientRecepies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecepies_Recepies_RecipeId",
                table: "IngredientRecepies",
                column: "RecipeId",
                principalTable: "Recepies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientRecepies_Recepies_RecipeId",
                table: "IngredientRecepies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecipeDate",
                table: "Recepies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "IngredientRecepies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientRecepies_Recepies_RecipeId",
                table: "IngredientRecepies",
                column: "RecipeId",
                principalTable: "Recepies",
                principalColumn: "Id");
        }
    }
}

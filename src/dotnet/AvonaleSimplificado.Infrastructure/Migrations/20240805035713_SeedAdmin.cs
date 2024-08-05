using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvonaleSimplificado.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CPF", "Email", "FirstName", "LastName", "Password", "Type" },
                values: new object[] { new Guid("962807e1-bed4-4613-ad1f-6bdb41cf4215"), "10574073051", "admin@email.com", "Avonale", "Administrador", "$2a$11$hS754Op/LwLTJaVttntGXu4ex6ckCnIh8huehn8khSO.OU5iyr/f.", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("962807e1-bed4-4613-ad1f-6bdb41cf4215"));
        }
    }
}

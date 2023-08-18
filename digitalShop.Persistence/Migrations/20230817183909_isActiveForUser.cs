using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitalShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class isActiveForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 17, 22, 9, 9, 632, DateTimeKind.Local).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 17, 22, 9, 9, 632, DateTimeKind.Local).AddTicks(6544));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 17, 22, 9, 9, 632, DateTimeKind.Local).AddTicks(6558));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "users");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 17, 22, 5, 21, 588, DateTimeKind.Local).AddTicks(6061));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 17, 22, 5, 21, 588, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 8, 17, 22, 5, 21, 588, DateTimeKind.Local).AddTicks(6151));
        }
    }
}

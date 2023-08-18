using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digitalShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addOptionBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "userInRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "roles",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedTime",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "userInRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "userInRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedTime",
                table: "userInRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "userInRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemovedTime",
                table: "roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "InsertTime", "IsRemoved", "RemovedTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 8, 17, 22, 5, 21, 588, DateTimeKind.Local).AddTicks(6061), false, null, null });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "InsertTime", "IsRemoved", "RemovedTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 8, 17, 22, 5, 21, 588, DateTimeKind.Local).AddTicks(6132), false, null, null });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "InsertTime", "IsRemoved", "RemovedTime", "UpdateTime" },
                values: new object[] { new DateTime(2023, 8, 17, 22, 5, 21, 588, DateTimeKind.Local).AddTicks(6151), false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RemovedTime",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "users");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "userInRoles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "userInRoles");

            migrationBuilder.DropColumn(
                name: "RemovedTime",
                table: "userInRoles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "userInRoles");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "RemovedTime",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "userInRoles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}

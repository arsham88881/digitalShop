using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace digitalShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_users_Id",
                table: "roles");

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "ID");

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                table: "roles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
              // .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "",
                table: "MyTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE MyTable SET NewColumn = OldColumn");

            migrationBuilder.DropColumn(
                name: "OldColumn",
                table: "MyTable");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "roles",
                newName: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "roles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
                //.OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemovedTime", "UpdateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 8, 19, 10, 36, 29, 603, DateTimeKind.Local).AddTicks(393), false, "Admin", null, null },
                    { 2L, new DateTime(2023, 8, 19, 10, 36, 29, 603, DateTimeKind.Local).AddTicks(580), false, "Operator", null, null },
                    { 3L, new DateTime(2023, 8, 19, 10, 36, 29, 603, DateTimeKind.Local).AddTicks(598), false, "Customer", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_roles_users_Id",
                table: "roles",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d1034ebc-802a-4d24-a157-6c21449a1e66"), "fd7332cd-168a-4ab7-9ebd-05ff8bcbffe6", "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d1034ebc-802a-4d24-a157-6c21449a1e66"));
        }
    }
}

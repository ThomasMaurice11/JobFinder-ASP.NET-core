using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eef7f90-99a8-4129-9ab8-5bf703fce6c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "242e533c-1bd5-46f9-b7e3-0379b2302f4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e7405b1-914a-41b7-91c6-8ce6f79a9064");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d5c2918-45d7-4d15-8ef5-d6e85087025a", null, "JobSeeker", "JOBSEEKER" },
                    { "3da16bc6-8490-40e2-84c1-dfead9d42f67", null, "Admin", "ADMIN" },
                    { "87f42ad1-f90d-4205-958e-8e7db8f657d8", null, "Emplpoyer", "EMPLOYER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d5c2918-45d7-4d15-8ef5-d6e85087025a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da16bc6-8490-40e2-84c1-dfead9d42f67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87f42ad1-f90d-4205-958e-8e7db8f657d8");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eef7f90-99a8-4129-9ab8-5bf703fce6c2", null, "JobSeeker", "JOBSEEKER" },
                    { "242e533c-1bd5-46f9-b7e3-0379b2302f4f", null, "Emplpoyer", "EMPLOYER" },
                    { "8e7405b1-914a-41b7-91c6-8ce6f79a9064", null, "Admin", "ADMIN" }
                });
        }
    }
}

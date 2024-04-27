using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07d78ef4-afc9-456b-9516-279ea43fc083");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc5f4f3e-0520-451e-91a3-29b8ce9110a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "daa2f179-789a-44c8-a18f-309844968ee7");

            migrationBuilder.CreateTable(
                name: "SendMessage",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendMessage", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_SendMessage_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendMessage_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eef7f90-99a8-4129-9ab8-5bf703fce6c2", null, "JobSeeker", "JOBSEEKER" },
                    { "242e533c-1bd5-46f9-b7e3-0379b2302f4f", null, "Emplpoyer", "EMPLOYER" },
                    { "8e7405b1-914a-41b7-91c6-8ce6f79a9064", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SendMessage_ReceiverId",
                table: "SendMessage",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_SendMessage_SenderId",
                table: "SendMessage",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendMessage");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07d78ef4-afc9-456b-9516-279ea43fc083", null, "JobSeeker", "JOBSEEKER" },
                    { "bc5f4f3e-0520-451e-91a3-29b8ce9110a1", null, "Emplpoyer", "EMPLOYER" },
                    { "daa2f179-789a-44c8-a18f-309844968ee7", null, "Admin", "ADMIN" }
                });
        }
    }
}

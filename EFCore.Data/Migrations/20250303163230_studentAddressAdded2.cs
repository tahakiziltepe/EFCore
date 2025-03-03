using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class studentAddressAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_addresses_students_student_id",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.AddForeignKey(
                name: "student_address_id_",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                principalSchema: "dbo",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_id_",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.AddForeignKey(
                name: "FK_student_addresses_students_student_id",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                principalSchema: "dbo",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

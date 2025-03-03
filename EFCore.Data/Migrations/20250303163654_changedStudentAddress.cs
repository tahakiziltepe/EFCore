using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedStudentAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_id_",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.DropIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.DropColumn(
                name: "student_id",
                schema: "dbo",
                table: "student_addresses");

            migrationBuilder.AddColumn<int>(
                name: "address_id",
                schema: "dbo",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_address_id",
                schema: "dbo",
                table: "students",
                column: "address_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "students",
                column: "address_id",
                principalSchema: "dbo",
                principalTable: "student_addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "student_address_student_id_fk",
                schema: "dbo",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_address_id",
                schema: "dbo",
                table: "students");

            migrationBuilder.DropColumn(
                name: "address_id",
                schema: "dbo",
                table: "students");

            migrationBuilder.AddColumn<int>(
                name: "student_id",
                schema: "dbo",
                table: "student_addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_student_addresses_student_id",
                schema: "dbo",
                table: "student_addresses",
                column: "student_id",
                unique: true);

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
    }
}

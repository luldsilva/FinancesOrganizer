using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class roleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "9d091c39-4089-4d1a-9237-a8ac74946f6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "c63344ce-b46b-4d60-8866-d915da3a1eff", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e625e8e-659a-4c4f-bd7c-093126a10007", "AQAAAAEAACcQAAAAEGzw9NEayem+msNGpNUfLw/hUCH3fTRNEDfe+m1GZdaumAwFDIboqli0QsJNgXyBjg==", "ed83b1e3-f561-476c-bdde-f261fb38518c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "188f240a-7a35-4e13-8f4b-4739e3078ce3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e92154ff-6c09-47b3-a293-0db174050122", "AQAAAAEAACcQAAAAEPd7lK19UOByWPezmE6R5dSgpqTyjIsjN/bQ4QvuM1UQ3/bpqjtGxhDzlqYb3u/Y6w==", "3add6eae-b279-4d8b-a6c2-3a3d4ab6b7f7" });
        }
    }
}

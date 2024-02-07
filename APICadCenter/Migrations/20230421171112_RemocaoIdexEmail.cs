using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICadCenter.Migrations
{
    public partial class RemocaoIdexEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_Email",
                table: "Pessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Email",
                table: "Pessoa",
                column: "Email",
                unique: true);
        }
    }
}

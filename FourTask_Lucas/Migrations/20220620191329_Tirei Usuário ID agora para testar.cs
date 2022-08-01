using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourTask_Lucas.Migrations
{
    public partial class TireiUsuárioIDagoraparatestar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Tarefa_AspNetUsers_UsuarioId1",
                table: "Tbl_Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Tarefa_UsuarioId1",
                table: "Tbl_Tarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Tbl_Tarefa");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Tbl_Tarefa",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Tarefa_UsuarioId",
                table: "Tbl_Tarefa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Tarefa_AspNetUsers_UsuarioId",
                table: "Tbl_Tarefa",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Tarefa_AspNetUsers_UsuarioId",
                table: "Tbl_Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tbl_Tarefa_UsuarioId",
                table: "Tbl_Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Tbl_Tarefa",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Tbl_Tarefa",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Tarefa_UsuarioId1",
                table: "Tbl_Tarefa",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Tarefa_AspNetUsers_UsuarioId1",
                table: "Tbl_Tarefa",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

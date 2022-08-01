using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourTask_Lucas.Migrations
{
    public partial class AdicionadoedepoisremovidoUsuarioIdeUsuariousuarioemModelsTarefaTestandoarelação : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Tarefa_Tbl_Equipe_EquipeId",
                table: "Tbl_Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Tbl_Tarefa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Tarefa_Tbl_Equipe_EquipeId",
                table: "Tbl_Tarefa",
                column: "EquipeId",
                principalTable: "Tbl_Equipe",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Tarefa_Tbl_Equipe_EquipeId",
                table: "Tbl_Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Tbl_Tarefa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Tarefa_Tbl_Equipe_EquipeId",
                table: "Tbl_Tarefa",
                column: "EquipeId",
                principalTable: "Tbl_Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

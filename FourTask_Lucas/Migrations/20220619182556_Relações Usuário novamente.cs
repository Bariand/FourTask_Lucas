using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourTask_Lucas.Migrations
{
    public partial class RelaçõesUsuárionovamente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tbl_Equipe_EquipeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tbl_Equipe_EquipeId",
                table: "AspNetUsers",
                column: "EquipeId",
                principalTable: "Tbl_Equipe",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tbl_Equipe_EquipeId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tbl_Equipe_EquipeId",
                table: "AspNetUsers",
                column: "EquipeId",
                principalTable: "Tbl_Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

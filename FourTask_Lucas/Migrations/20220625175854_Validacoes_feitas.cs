using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FourTask_Lucas.Migrations
{
    public partial class Validacoes_feitas : Migration
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Tbl_Tarefa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Tbl_Tarefa",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

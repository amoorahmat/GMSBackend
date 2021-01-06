﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GMSBackend.Migrations
{
    public partial class userrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRolesId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRolesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRolesId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserRolesId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRolesId",
                table: "Users",
                column: "UserRolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRolesId",
                table: "Users",
                column: "UserRolesId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RssReaderModel.Migrations
{
    public partial class RenameBlogNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_RssFeedId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Feeds");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_RssFeedId",
                table: "Articles",
                newName: "IX_Articles_RssFeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feeds",
                table: "Feeds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Feeds_RssFeedId",
                table: "Articles",
                column: "RssFeedId",
                principalTable: "Feeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Feeds_RssFeedId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feeds",
                table: "Feeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Feeds",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_RssFeedId",
                table: "Posts",
                newName: "IX_Posts_RssFeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_RssFeedId",
                table: "Posts",
                column: "RssFeedId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

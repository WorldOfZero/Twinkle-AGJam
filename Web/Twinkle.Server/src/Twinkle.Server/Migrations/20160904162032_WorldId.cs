using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Twinkle.Server.Migrations
{
    public partial class WorldId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorldId",
                table: "WorldModel",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "WorldId", table: "WorldModel");
        }
    }
}

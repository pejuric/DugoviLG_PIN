using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DugoviLG_PIN.Migrations
{
    public partial class MyMig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurDugovi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum_Posudbe = table.Column<DateTime>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    PosuđenNovac_Kn = table.Column<double>(nullable: false),
                    Prezime = table.Column<string>(nullable: true),
                    Rok_Povratka = table.Column<DateTime>(nullable: false),
                    Tjedne_Kamate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurDugovi", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurDugovi");
        }
    }
}

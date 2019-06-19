using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalisOOAD.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Anketa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    doktorID = table.Column<int>(nullable: false),
                    ocjena1 = table.Column<int>(nullable: false),
                    ocjena2 = table.Column<int>(nullable: false),
                    ocjena3 = table.Column<int>(nullable: false),
                    ocjena4 = table.Column<int>(nullable: false),
                    ocjena5 = table.Column<int>(nullable: false),
                    konacnaOcjena = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anketa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InfoAplikacije",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tekst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoAplikacije", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InfoBolnice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoBolnice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ime = table.Column<string>(nullable: false),
                    prezime = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    kontaktTelefon = table.Column<string>(nullable: false),
                    username = table.Column<string>(nullable: false),
                    passwordHash = table.Column<string>(nullable: false),
                    spol = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    verKod = table.Column<string>(nullable: true),
                    Odjel = table.Column<string>(nullable: true),
                    jmbg = table.Column<string>(nullable: true),
                    datumRodjenja = table.Column<DateTime>(nullable: true),
                    adresaPrebivalista = table.Column<string>(nullable: true),
                    gradRodjenja = table.Column<string>(nullable: true),
                    drzavaRodjenja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Obavjestenje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tekst = table.Column<string>(nullable: false),
                    vrijemeObjave = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavjestenje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dokumentacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    datumIzdavanja = table.Column<DateTime>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    rezultatPregleda = table.Column<string>(nullable: true),
                    nazivLijeka = table.Column<string>(nullable: true),
                    svrha = table.Column<string>(nullable: true),
                    odrediste = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumentacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dokumentacija_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregled",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    termin = table.Column<DateTime>(nullable: false),
                    zauzet = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: false),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregled", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pregled_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dokumentacija_KorisnikId",
                table: "Dokumentacija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_KorisnikId",
                table: "Pregled",
                column: "KorisnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Anketa");

            migrationBuilder.DropTable(
                name: "Dokumentacija");

            migrationBuilder.DropTable(
                name: "InfoAplikacije");

            migrationBuilder.DropTable(
                name: "InfoBolnice");

            migrationBuilder.DropTable(
                name: "Obavjestenje");

            migrationBuilder.DropTable(
                name: "Pregled");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}

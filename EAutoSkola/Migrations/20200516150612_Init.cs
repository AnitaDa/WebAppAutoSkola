using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EAutoSkola.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RasporedPolaganja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPolaganja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporedPolaganja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Satnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminOD = table.Column<string>(nullable: true),
                    TerminDO = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Satnica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipUposlenika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naizv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUposlenika", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZdrastveniRadnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(nullable: true),
                    Specijalizacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZdrastveniRadnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Kandidati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(maxLength: 14, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kandidati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kandidati_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    JMBG = table.Column<string>(maxLength: 14, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    KorisnikId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uposlenici_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    Cijena = table.Column<float>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usluge_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Vozila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodinaProizvodnje = table.Column<int>(nullable: false),
                    Marka = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    RegistarskaOznaka = table.Column<string>(nullable: true),
                    KategorijaId = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozila", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vozila_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LjekarskoUvjerenje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzdavanje = table.Column<DateTime>(nullable: false),
                    DatumVazenja = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    KandidatId = table.Column<int>(nullable: false),
                    SposobanZaObuku = table.Column<bool>(nullable: false),
                    ZdrastveniRadnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LjekarskoUvjerenje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LjekarskoUvjerenje_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LjekarskoUvjerenje_ZdrastveniRadnik_ZdrastveniRadnikId",
                        column: x => x.ZdrastveniRadnikId,
                        principalTable: "ZdrastveniRadnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Potvrde",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPolaganja = table.Column<DateTime>(nullable: false),
                    BrojBodova = table.Column<int>(nullable: false),
                    KandidatId = table.Column<int>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potvrde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Potvrde_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Potvrde_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RasporedCasova",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KandidatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporedCasova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RasporedCasova_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TerminRasporedPolaganja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminOd = table.Column<string>(nullable: true),
                    TerminDo = table.Column<string>(nullable: true),
                    KandidatId = table.Column<int>(nullable: false),
                    RasporedPolaganjaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminRasporedPolaganja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminRasporedPolaganja_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TerminRasporedPolaganja_RasporedPolaganja_RasporedPolaganjaId",
                        column: x => x.RasporedPolaganjaId,
                        principalTable: "RasporedPolaganja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Plata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iznos = table.Column<float>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    UposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plata_Uposlenici_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<float>(nullable: false),
                    Svrha = table.Column<string>(nullable: true),
                    KandidatId = table.Column<int>(nullable: false),
                    UposlenikId = table.Column<int>(nullable: false),
                    Pretraga = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplate_Kandidati_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "Kandidati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Uplate_Uposlenici_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "uposlenikTipUposlenika",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(nullable: true),
                    TipUposlenikaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uposlenikTipUposlenika", x => x.Id);
                    table.ForeignKey(
                        name: "FK_uposlenikTipUposlenika_TipUposlenika_TipUposlenikaId",
                        column: x => x.TipUposlenikaId,
                        principalTable: "TipUposlenika",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_uposlenikTipUposlenika_Uposlenici_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPodnosenjaZahtjeva = table.Column<DateTime>(nullable: false),
                    LjekarskoUvjerenjeId = table.Column<int>(nullable: false),
                    UslugaId = table.Column<int>(nullable: false),
                    Procitano = table.Column<bool>(nullable: false),
                    Odbacen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtjev_LjekarskoUvjerenje_LjekarskoUvjerenjeId",
                        column: x => x.LjekarskoUvjerenjeId,
                        principalTable: "LjekarskoUvjerenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RasporedCasovaInstruktor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstruktorId = table.Column<int>(nullable: true),
                    RasporedCasovaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RasporedCasovaInstruktor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RasporedCasovaInstruktor_Uposlenici_InstruktorId",
                        column: x => x.InstruktorId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RasporedCasovaInstruktor_RasporedCasova_RasporedCasovaId",
                        column: x => x.RasporedCasovaId,
                        principalTable: "RasporedCasova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerminRasporedaCasova",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    TerminOd = table.Column<string>(nullable: true),
                    TerminDo = table.Column<string>(nullable: true),
                    UposlenikId = table.Column<int>(nullable: false),
                    RasporedCasovaId = table.Column<int>(nullable: false),
                    VoziloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminRasporedaCasova", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerminRasporedaCasova_RasporedCasova_RasporedCasovaId",
                        column: x => x.RasporedCasovaId,
                        principalTable: "RasporedCasova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TerminRasporedaCasova_Uposlenici_UposlenikId",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TerminRasporedaCasova_Vozila_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozila",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kandidati_KorisnikId",
                table: "Kandidati",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_LjekarskoUvjerenje_KandidatId",
                table: "LjekarskoUvjerenje",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_LjekarskoUvjerenje_ZdrastveniRadnikId",
                table: "LjekarskoUvjerenje",
                column: "ZdrastveniRadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Plata_UposlenikId",
                table: "Plata",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Potvrde_KandidatId",
                table: "Potvrde",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Potvrde_KategorijaId",
                table: "Potvrde",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedCasova_KandidatId",
                table: "RasporedCasova",
                column: "KandidatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RasporedCasovaInstruktor_InstruktorId",
                table: "RasporedCasovaInstruktor",
                column: "InstruktorId");

            migrationBuilder.CreateIndex(
                name: "IX_RasporedCasovaInstruktor_RasporedCasovaId",
                table: "RasporedCasovaInstruktor",
                column: "RasporedCasovaId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminRasporedaCasova_RasporedCasovaId",
                table: "TerminRasporedaCasova",
                column: "RasporedCasovaId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminRasporedaCasova_UposlenikId",
                table: "TerminRasporedaCasova",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminRasporedaCasova_VoziloId",
                table: "TerminRasporedaCasova",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminRasporedPolaganja_KandidatId",
                table: "TerminRasporedPolaganja",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminRasporedPolaganja_RasporedPolaganjaId",
                table: "TerminRasporedPolaganja",
                column: "RasporedPolaganjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_KandidatId",
                table: "Uplate",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplate_UposlenikId",
                table: "Uplate",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenici_KorisnikId",
                table: "Uposlenici",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_uposlenikTipUposlenika_TipUposlenikaId",
                table: "uposlenikTipUposlenika",
                column: "TipUposlenikaId");

            migrationBuilder.CreateIndex(
                name: "IX_uposlenikTipUposlenika_UposlenikId",
                table: "uposlenikTipUposlenika",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_KategorijaId",
                table: "Usluge",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozila_KategorijaId",
                table: "Vozila",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_LjekarskoUvjerenjeId",
                table: "Zahtjev",
                column: "LjekarskoUvjerenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_UslugaId",
                table: "Zahtjev",
                column: "UslugaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Plata");

            migrationBuilder.DropTable(
                name: "Potvrde");

            migrationBuilder.DropTable(
                name: "RasporedCasovaInstruktor");

            migrationBuilder.DropTable(
                name: "Satnica");

            migrationBuilder.DropTable(
                name: "TerminRasporedaCasova");

            migrationBuilder.DropTable(
                name: "TerminRasporedPolaganja");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "uposlenikTipUposlenika");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RasporedCasova");

            migrationBuilder.DropTable(
                name: "Vozila");

            migrationBuilder.DropTable(
                name: "RasporedPolaganja");

            migrationBuilder.DropTable(
                name: "TipUposlenika");

            migrationBuilder.DropTable(
                name: "Uposlenici");

            migrationBuilder.DropTable(
                name: "LjekarskoUvjerenje");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "Kandidati");

            migrationBuilder.DropTable(
                name: "ZdrastveniRadnik");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

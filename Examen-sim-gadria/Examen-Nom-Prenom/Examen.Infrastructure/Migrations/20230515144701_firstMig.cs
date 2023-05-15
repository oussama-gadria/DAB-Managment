using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banque",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banque", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DAB",
                columns: table => new
                {
                    DabId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAB", x => x.DabId);
                });

            migrationBuilder.CreateTable(
                name: "Exemple",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemple", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compte",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Propriétaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BanqueFk = table.Column<int>(type: "int", nullable: false),
                    BanqueCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compte", x => x.NumeroCompte);
                    table.ForeignKey(
                        name: "FK_Compte_Banque_BanqueCode",
                        column: x => x.BanqueCode,
                        principalTable: "Banque",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => new { x.NumeroCompteFk, x.DABFk, x.Date });
                    table.ForeignKey(
                        name: "FK_Transaction_Compte_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Compte",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_DAB_DABFk",
                        column: x => x.DABFk,
                        principalTable: "DAB",
                        principalColumn: "DabId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionRetrait",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AutreAgence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRetrait", x => new { x.NumeroCompteFk, x.DABFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_Compte_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Compte",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_DAB_DABFk",
                        column: x => x.DABFk,
                        principalTable: "DAB",
                        principalColumn: "DabId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionRetrait_Transaction_NumeroCompteFk_DABFk_Date",
                        columns: x => new { x.NumeroCompteFk, x.DABFk, x.Date },
                        principalTable: "Transaction",
                        principalColumns: new[] { "NumeroCompteFk", "DABFk", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTransfert",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumeroCompte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTransfert", x => new { x.NumeroCompteFk, x.DABFk, x.Date });
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_Compte_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Compte",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_DAB_DABFk",
                        column: x => x.DABFk,
                        principalTable: "DAB",
                        principalColumn: "DabId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionTransfert_Transaction_NumeroCompteFk_DABFk_Date",
                        columns: x => new { x.NumeroCompteFk, x.DABFk, x.Date },
                        principalTable: "Transaction",
                        principalColumns: new[] { "NumeroCompteFk", "DABFk", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compte_BanqueCode",
                table: "Compte",
                column: "BanqueCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_DABFk",
                table: "Transaction",
                column: "DABFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRetrait_DABFk",
                table: "TransactionRetrait",
                column: "DABFk");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionTransfert_DABFk",
                table: "TransactionTransfert",
                column: "DABFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemple");

            migrationBuilder.DropTable(
                name: "TransactionRetrait");

            migrationBuilder.DropTable(
                name: "TransactionTransfert");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Compte");

            migrationBuilder.DropTable(
                name: "DAB");

            migrationBuilder.DropTable(
                name: "Banque");
        }
    }
}

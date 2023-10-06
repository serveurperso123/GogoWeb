using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GogoWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cni",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Etat",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumCapacite",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumPermi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ModePaiements",
                columns: table => new
                {
                    ModePaiementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LibelleMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pourcentage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModePaiements", x => x.ModePaiementId);
                });

            migrationBuilder.CreateTable(
                name: "Plaintes",
                columns: table => new
                {
                    PlainteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GogoWebUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LibellePlainte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePlainte = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plaintes", x => x.PlainteId);
                    table.ForeignKey(
                        name: "FK_Plaintes_AspNetUsers_GogoWebUserId",
                        column: x => x.GogoWebUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sos",
                columns: table => new
                {
                    SoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GogoWebUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Localisation = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sos", x => x.SoId);
                    table.ForeignKey(
                        name: "FK_Sos_AspNetUsers_GogoWebUserId",
                        column: x => x.GogoWebUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeReservations",
                columns: table => new
                {
                    TypeReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrixUnitaire = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TauxPeriodique = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeReservations", x => x.TypeReservationId);
                });

            migrationBuilder.CreateTable(
                name: "TypeVehicules",
                columns: table => new
                {
                    TypevehiculeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Standard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeVehicules", x => x.TypevehiculeId);
                });

            migrationBuilder.CreateTable(
                name: "Paiements",
                columns: table => new
                {
                    PaiementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModePaiementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MomtantPaiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<long>(type: "bigint", nullable: true),
                    DatePaiement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EtatPaiement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facturation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiements", x => x.PaiementId);
                    table.ForeignKey(
                        name: "FK_Paiements_ModePaiements_ModePaiementId",
                        column: x => x.ModePaiementId,
                        principalTable: "ModePaiements",
                        principalColumn: "ModePaiementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservtions",
                columns: table => new
                {
                    ReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GogoWebUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Position = table.Column<bool>(type: "bit", nullable: true),
                    NbrePassages = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservtions", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservtions_AspNetUsers_GogoWebUserId",
                        column: x => x.GogoWebUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservtions_TypeReservations_TypeReservationId",
                        column: x => x.TypeReservationId,
                        principalTable: "TypeReservations",
                        principalColumn: "TypeReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    VehiculeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypevehiculeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TypeReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomVehicule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Immatriculation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Couleur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Assurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroChassis = table.Column<int>(type: "int", nullable: true),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.VehiculeId);
                    table.ForeignKey(
                        name: "FK_Vehicules_TypeReservations_TypeReservationId",
                        column: x => x.TypeReservationId,
                        principalTable: "TypeReservations",
                        principalColumn: "TypeReservationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicules_TypeVehicules_TypevehiculeId",
                        column: x => x.TypevehiculeId,
                        principalTable: "TypeVehicules",
                        principalColumn: "TypevehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaiementReservation",
                columns: table => new
                {
                    IdPaiementsPaiementId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdReservationsReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementReservation", x => new { x.IdPaiementsPaiementId, x.IdReservationsReservationId });
                    table.ForeignKey(
                        name: "FK_PaiementReservation_Paiements_IdPaiementsPaiementId",
                        column: x => x.IdPaiementsPaiementId,
                        principalTable: "Paiements",
                        principalColumn: "PaiementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaiementReservation_Reservtions_IdReservationsReservationId",
                        column: x => x.IdReservationsReservationId,
                        principalTable: "Reservtions",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehiculeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCourse = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureCourse = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EtatCourse = table.Column<int>(type: "int", nullable: true),
                    Destination = table.Column<bool>(type: "bit", nullable: true),
                    Position = table.Column<bool>(type: "bit", nullable: true),
                    ReservationIdNavigationReservationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Reservtions_ReservationIdNavigationReservationId",
                        column: x => x.ReservationIdNavigationReservationId,
                        principalTable: "Reservtions",
                        principalColumn: "ReservationId");
                    table.ForeignKey(
                        name: "FK_Courses_Vehicules_VehiculeId",
                        column: x => x.VehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GogoWebUserVehicule",
                columns: table => new
                {
                    IdVehiculesVehiculeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GogoWebUserVehicule", x => new { x.IdVehiculesVehiculeId, x.IdsId });
                    table.ForeignKey(
                        name: "FK_GogoWebUserVehicule_AspNetUsers_IdsId",
                        column: x => x.IdsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GogoWebUserVehicule_Vehicules_IdVehiculesVehiculeId",
                        column: x => x.IdVehiculesVehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ReservationIdNavigationReservationId",
                table: "Courses",
                column: "ReservationIdNavigationReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_VehiculeId",
                table: "Courses",
                column: "VehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_GogoWebUserVehicule_IdsId",
                table: "GogoWebUserVehicule",
                column: "IdsId");

            migrationBuilder.CreateIndex(
                name: "IX_PaiementReservation_IdReservationsReservationId",
                table: "PaiementReservation",
                column: "IdReservationsReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiements_ModePaiementId",
                table: "Paiements",
                column: "ModePaiementId");

            migrationBuilder.CreateIndex(
                name: "IX_Plaintes_GogoWebUserId",
                table: "Plaintes",
                column: "GogoWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservtions_GogoWebUserId",
                table: "Reservtions",
                column: "GogoWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservtions_TypeReservationId",
                table: "Reservtions",
                column: "TypeReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sos_GogoWebUserId",
                table: "Sos",
                column: "GogoWebUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_TypeReservationId",
                table: "Vehicules",
                column: "TypeReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_TypevehiculeId",
                table: "Vehicules",
                column: "TypevehiculeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "GogoWebUserVehicule");

            migrationBuilder.DropTable(
                name: "PaiementReservation");

            migrationBuilder.DropTable(
                name: "Plaintes");

            migrationBuilder.DropTable(
                name: "Sos");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "Paiements");

            migrationBuilder.DropTable(
                name: "Reservtions");

            migrationBuilder.DropTable(
                name: "TypeVehicules");

            migrationBuilder.DropTable(
                name: "ModePaiements");

            migrationBuilder.DropTable(
                name: "TypeReservations");

            migrationBuilder.DropColumn(
                name: "Cni",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Etat",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumCapacite",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NumPermi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sexe",
                table: "AspNetUsers");
        }
    }
}

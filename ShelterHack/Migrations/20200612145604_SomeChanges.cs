using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ShelterHack.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatchServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatchServiceEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AuthDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchServiceEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatchServiceEmployees_AuthData_AuthDataId",
                        column: x => x.AuthDataId,
                        principalTable: "AuthData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: true),
                    AuthDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AuthData_AuthDataId",
                        column: x => x.AuthDataId,
                        principalTable: "AuthData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(nullable: true),
                    Point = table.Column<string>(nullable: true),
                    PerformerShelterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Shelters_PerformerShelterId",
                        column: x => x.PerformerShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShelterEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: true),
                    AuthDataId = table.Column<int>(nullable: true),
                    ShelterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterEmployees_AuthData_AuthDataId",
                        column: x => x.AuthDataId,
                        principalTable: "AuthData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShelterEmployees_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContractId = table.Column<int>(nullable: true),
                    DeclarantShelterId = table.Column<int>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Shelters_DeclarantShelterId",
                        column: x => x.DeclarantShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ArrivedInShelter = table.Column<DateTime>(nullable: false),
                    ShelterContainerId = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    CatcherId = table.Column<int>(nullable: true),
                    CatchServiceId = table.Column<int>(nullable: true),
                    ContractId = table.Column<int>(nullable: true),
                    ShelterEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_CatchServices_CatchServiceId",
                        column: x => x.CatchServiceId,
                        principalTable: "CatchServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_CatchServiceEmployees_CatcherId",
                        column: x => x.CatcherId,
                        principalTable: "CatchServiceEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Shelters_ShelterContainerId",
                        column: x => x.ShelterContainerId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_ShelterEmployees_ShelterEmployeeId",
                        column: x => x.ShelterEmployeeId,
                        principalTable: "ShelterEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CatchServiceId",
                table: "Animals",
                column: "CatchServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CatcherId",
                table: "Animals",
                column: "CatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ContractId",
                table: "Animals",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ShelterContainerId",
                table: "Animals",
                column: "ShelterContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ShelterEmployeeId",
                table: "Animals",
                column: "ShelterEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatchServiceEmployees_AuthDataId",
                table: "CatchServiceEmployees",
                column: "AuthDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PerformerShelterId",
                table: "Contracts",
                column: "PerformerShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ContractId",
                table: "Requests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeclarantShelterId",
                table: "Requests",
                column: "DeclarantShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterEmployees_AuthDataId",
                table: "ShelterEmployees",
                column: "AuthDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterEmployees_ShelterId",
                table: "ShelterEmployees",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthDataId",
                table: "Users",
                column: "AuthDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CatchServices");

            migrationBuilder.DropTable(
                name: "CatchServiceEmployees");

            migrationBuilder.DropTable(
                name: "ShelterEmployees");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "AuthData");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}

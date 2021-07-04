using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UF_Municipio_CEP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UF",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    FederateUnit = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CodIBGE = table.Column<int>(nullable: false),
                    UFId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                    table.ForeignKey(
                        name: "FK_County_UF_UFId",
                        column: x => x.UFId,
                        principalTable: "UF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CEP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CEP = table.Column<string>(maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 60, nullable: false),
                    Numero = table.Column<string>(maxLength: 10, nullable: true),
                    CountyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CEP_County_CountyID",
                        column: x => x.CountyID,
                        principalTable: "County",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UF",
                columns: new[] { "Id", "CreateAt", "FederateUnit", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5718), "AC", "Acre", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5826), "SP", "São Paulo", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5824), "SE", "Sergipe", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5821), "SC", "Santa Catarina", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5819), "RS", "Rio Grande do Sul", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5817), "RR", "Roraima", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5815), "RO", "Rondônia", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5812), "RN", "Rio Grande do Norte", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5810), "RJ", "Rio de Janeiro", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5808), "PR", "Paraná", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5806), "PI", "Piauí", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5804), "PE", "Pernambuco", null },
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5801), "PB", "Paraíba", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5800), "PA", "Pará", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5796), "MT", "Mato Grosso", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5794), "MS", "Mato Grosso do Sul", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5792), "MG", "Minas Gerais", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5790), "MA", "Maranhão", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5788), "GO", "Goiás", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5785), "ES", "Espírito Santo", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5783), "DF", "Distrito Federal", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5781), "CE", "Ceará", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5779), "BA", "Bahia", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5777), "AP", "Amapá", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5774), "AM", "Amazonas", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5770), "AL", "Alagoas", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), new DateTime(2021, 7, 4, 21, 0, 55, 801, DateTimeKind.Utc).AddTicks(5861), "TO", "Tocantins", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("bfb40ab2-8e08-43a5-8219-1e36660130e3"), new DateTime(2021, 7, 4, 18, 0, 55, 798, DateTimeKind.Local).AddTicks(9570), "administrator@hotmail.com", "Administrator", null });

            migrationBuilder.CreateIndex(
                name: "IX_CEP_CEP",
                table: "CEP",
                column: "CEP");

            migrationBuilder.CreateIndex(
                name: "IX_CEP_CountyID",
                table: "CEP",
                column: "CountyID");

            migrationBuilder.CreateIndex(
                name: "IX_County_CodIBGE",
                table: "County",
                column: "CodIBGE");

            migrationBuilder.CreateIndex(
                name: "IX_County_UFId",
                table: "County",
                column: "UFId");

            migrationBuilder.CreateIndex(
                name: "IX_UF_FederateUnit",
                table: "UF",
                column: "FederateUnit",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CEP");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "UF");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bfb40ab2-8e08-43a5-8219-1e36660130e3"));
        }
    }
}

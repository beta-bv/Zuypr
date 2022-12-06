using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfielImageURI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matchid = table.Column<int>(type: "int", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Users_Matchs_Matchid",
                        column: x => x.Matchid,
                        principalTable: "Matchs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkType = table.Column<int>(type: "int", nullable: false),
                    DrinkName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DrinkImageURI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserEmail2 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => new { x.DrinkType, x.DrinkName });
                    table.ForeignKey(
                        name: "FK_Drinks_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Drinks_Users_UserEmail1",
                        column: x => x.UserEmail1,
                        principalTable: "Users",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Drinks_Users_UserEmail2",
                        column: x => x.UserEmail2,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Zipcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => new { x.City, x.Street, x.Zipcode, x.Number, x.Suffix });
                    table.ForeignKey(
                        name: "FK_Locations_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Text = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Matchid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => new { x.Text, x.TimeSent });
                    table.ForeignKey(
                        name: "FK_Message_Matchs_Matchid",
                        column: x => x.Matchid,
                        principalTable: "Matchs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Message_Users_SenderEmail",
                        column: x => x.SenderEmail,
                        principalTable: "Users",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_UserEmail",
                table: "Drinks",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_UserEmail1",
                table: "Drinks",
                column: "UserEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_UserEmail2",
                table: "Drinks",
                column: "UserEmail2");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserEmail",
                table: "Locations",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Matchid",
                table: "Message",
                column: "Matchid");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderEmail",
                table: "Message",
                column: "SenderEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Matchid",
                table: "Users",
                column: "Matchid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Matchs");
        }
    }
}

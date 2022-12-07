using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Users_UserEmail",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Users_UserEmail1",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Users_UserEmail2",
                table: "Drinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Users_UserEmail",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Matchs_Matchid",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_SenderEmail",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Matchs_Matchid",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserEmail",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserEmail",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Message_SenderEmail",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserEmail",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_UserEmail",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_UserEmail1",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_UserEmail2",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "UserEmail1",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "UserEmail2",
                table: "Drinks");

            migrationBuilder.RenameColumn(
                name: "Matchid",
                table: "Users",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Matchid",
                table: "Users",
                newName: "IX_Users_MatchId");

            migrationBuilder.RenameColumn(
                name: "Matchid",
                table: "Message",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_Matchid",
                table: "Message",
                newName: "IX_Message_MatchId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Matchs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DrinkImageURI",
                table: "Drinks",
                newName: "DrinkImage");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DrinkName",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderId",
                table: "Message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Matchs_MatchId",
                table: "Message",
                column: "MatchId",
                principalTable: "Matchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Matchs_MatchId",
                table: "Users",
                column: "MatchId",
                principalTable: "Matchs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Users_UserId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Matchs_MatchId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Matchs_MatchId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Message_SenderId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Locations_UserId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Drinks");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Users",
                newName: "Matchid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_MatchId",
                table: "Users",
                newName: "IX_Users_Matchid");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Message",
                newName: "Matchid");

            migrationBuilder.RenameIndex(
                name: "IX_Message_MatchId",
                table: "Message",
                newName: "IX_Message_Matchid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Matchs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DrinkImage",
                table: "Drinks",
                newName: "DrinkImageURI");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Locations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DrinkName",
                table: "Drinks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Drinks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail1",
                table: "Drinks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail2",
                table: "Drinks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drinks",
                table: "Drinks",
                columns: new[] { "DrinkType", "DrinkName" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderEmail",
                table: "Message",
                column: "SenderEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserEmail",
                table: "Locations",
                column: "UserEmail");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Users_UserEmail",
                table: "Drinks",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Users_UserEmail1",
                table: "Drinks",
                column: "UserEmail1",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Users_UserEmail2",
                table: "Drinks",
                column: "UserEmail2",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Users_UserEmail",
                table: "Locations",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Matchs_Matchid",
                table: "Message",
                column: "Matchid",
                principalTable: "Matchs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_SenderEmail",
                table: "Message",
                column: "SenderEmail",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Matchs_Matchid",
                table: "Users",
                column: "Matchid",
                principalTable: "Matchs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Aggregator_Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USers",
                columns: table => new
                {
                    US_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    US_user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    US_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    US_user_role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    US_user_status = table.Column<bool>(type: "bit", nullable: false),
                    US_positivity_treshold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USers", x => x.US_user_id);
                });

            migrationBuilder.CreateTable(
                name: "ARticles",
                columns: table => new
                {
                    AR_art_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AR_content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AR_source_adr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AR_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AR_positivity = table.Column<int>(type: "int", nullable: false),
                    AR_art_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARticles", x => x.AR_art_id);
                    table.ForeignKey(
                        name: "FK_ARticles_USers_AR_user_id",
                        column: x => x.AR_user_id,
                        principalTable: "USers",
                        principalColumn: "US_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COmments",
                columns: table => new
                {
                    CO_comment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CO_art_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CO_user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CO_comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CO_comm_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COmments", x => x.CO_comment_id);
                    table.ForeignKey(
                        name: "FK_COmments_ARticles_CO_art_id",
                        column: x => x.CO_art_id,
                        principalTable: "ARticles",
                        principalColumn: "AR_art_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COmments_USers_CO_user_id",
                        column: x => x.CO_user_id,
                        principalTable: "USers",
                        principalColumn: "US_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ARticles_AR_user_id",
                table: "ARticles",
                column: "AR_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_COmments_CO_art_id",
                table: "COmments",
                column: "CO_art_id");

            migrationBuilder.CreateIndex(
                name: "IX_COmments_CO_user_id",
                table: "COmments",
                column: "CO_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COmments");

            migrationBuilder.DropTable(
                name: "ARticles");

            migrationBuilder.DropTable(
                name: "USers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ribbons.Users.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_user_type",
                columns: table => new
                {
                    user_type_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_type", x => x.user_type_id);
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_id = table.Column<long>(type: "bigint", nullable: false),
                    username = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_status_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_token_type",
                columns: table => new
                {
                    user_token_type_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_type_id = table.Column<long>(type: "bigint", nullable: false),
                    code = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_token_type", x => x.user_token_type_id);
                    table.ForeignKey(
                        name: "FK_t_user_token_type_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_email",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_type_id = table.Column<long>(type: "bigint", nullable: false),
                    email_address = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_verified = table.Column<bool>(type: "bit", nullable: false),
                    verified_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_email", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_email_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_password",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    password_salt = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    password_hash = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_expired = table.Column<bool>(type: "bit", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_password", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_password_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_phone",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_type_id = table.Column<long>(type: "bigint", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_verified = table.Column<bool>(type: "bit", nullable: false),
                    verified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_phone", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_phone_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_session",
                columns: table => new
                {
                    user_session_id = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    session_secret_salt = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    session_secret_hash = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_expired = table.Column<bool>(type: "bit", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_session", x => x.user_session_id);
                    table.ForeignKey(
                        name: "FK_t_user_session_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_token",
                columns: table => new
                {
                    user_token_id = table.Column<byte[]>(type: "varbinary(64)", maxLength: 64, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    user_token_type_id = table.Column<long>(type: "bigint", nullable: false),
                    token_secret_salt = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    token_secret_hash = table.Column<byte[]>(type: "varbinary(512)", maxLength: 512, nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_expired = table.Column<bool>(type: "bit", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    is_consumed = table.Column<bool>(type: "bit", nullable: false),
                    consumed_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_token", x => x.user_token_id);
                    table.ForeignKey(
                        name: "FK_t_user_token_t_user_token_type_user_token_type_id",
                        column: x => x.user_token_type_id,
                        principalTable: "t_user_token_type",
                        principalColumn: "user_token_type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_user_token_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_user_created_date",
                table: "t_user",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_modified_date",
                table: "t_user",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_user_status_id",
                table: "t_user",
                column: "user_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_user_type_id",
                table: "t_user",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_user_type_id_username",
                table: "t_user",
                columns: new[] { "user_type_id", "username" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_username",
                table: "t_user",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_created_date",
                table: "t_user_email",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_email_address",
                table: "t_user_email",
                column: "email_address");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_is_verified",
                table: "t_user_email",
                column: "is_verified");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_modified_date",
                table: "t_user_email",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_user_type_id",
                table: "t_user_email",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_user_type_id_email_address",
                table: "t_user_email",
                columns: new[] { "user_type_id", "email_address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_email_verified_date",
                table: "t_user_email",
                column: "verified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_created_date",
                table: "t_user_password",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_expiry_date",
                table: "t_user_password",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_is_expired",
                table: "t_user_password",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_password_modified_date",
                table: "t_user_password",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_created_date",
                table: "t_user_session",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_expiry_date",
                table: "t_user_session",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_is_expired",
                table: "t_user_session",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_session_user_id",
                table: "t_user_session",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_consumed_date",
                table: "t_user_token",
                column: "consumed_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_created_date",
                table: "t_user_token",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_expiry_date",
                table: "t_user_token",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_is_consumed",
                table: "t_user_token",
                column: "is_consumed");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_is_expired",
                table: "t_user_token",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_user_id",
                table: "t_user_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_user_token_type_id",
                table: "t_user_token",
                column: "user_token_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_type_code",
                table: "t_user_token_type",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_type_created_date",
                table: "t_user_token_type",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_type_modified_date",
                table: "t_user_token_type",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_type_user_type_id",
                table: "t_user_token_type",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_token_type_user_type_id_code",
                table: "t_user_token_type",
                columns: new[] { "user_type_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_code",
                table: "t_user_type",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_created_date",
                table: "t_user_type",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_modified_date",
                table: "t_user_type",
                column: "modified_date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_user_email");

            migrationBuilder.DropTable(
                name: "t_user_password");

            migrationBuilder.DropTable(
                name: "t_user_phone");

            migrationBuilder.DropTable(
                name: "t_user_session");

            migrationBuilder.DropTable(
                name: "t_user_token");

            migrationBuilder.DropTable(
                name: "t_user_token_type");

            migrationBuilder.DropTable(
                name: "t_user");

            migrationBuilder.DropTable(
                name: "t_user_type");
        }
    }
}

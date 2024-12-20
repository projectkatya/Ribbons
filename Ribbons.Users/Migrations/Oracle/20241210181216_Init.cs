﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ribbons.Users.Migrations.Oracle
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_user_scope",
                columns: table => new
                {
                    user_scope_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_scope", x => x.user_scope_id);
                });

            migrationBuilder.CreateTable(
                name: "t_user_scope_alias",
                columns: table => new
                {
                    user_scope_alias_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_scope_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_scope_alias", x => x.user_scope_alias_id);
                    table.ForeignKey(
                        name: "FK_t_user_scope_alias_t_user_scope_user_scope_id",
                        column: x => x.user_scope_id,
                        principalTable: "t_user_scope",
                        principalColumn: "user_scope_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_type",
                columns: table => new
                {
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_scope_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_type", x => x.user_type_id);
                    table.ForeignKey(
                        name: "FK_t_user_type_t_user_scope_user_scope_id",
                        column: x => x.user_scope_id,
                        principalTable: "t_user_scope",
                        principalColumn: "user_scope_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_attribute_type",
                columns: table => new
                {
                    user_attribute_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    value_type = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_attribute_type", x => x.user_attribute_type_id);
                    table.ForeignKey(
                        name: "FK_t_user_attribute_type_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_credential_type",
                columns: table => new
                {
                    user_credential_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_credential_type", x => x.user_credential_type_id);
                    table.ForeignKey(
                        name: "FK_t_user_credential_type_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_group",
                columns: table => new
                {
                    user_group_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_group", x => x.user_group_id);
                    table.ForeignKey(
                        name: "FK_t_user_group_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_status",
                columns: table => new
                {
                    user_status_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_status", x => x.user_status_id);
                    table.ForeignKey(
                        name: "FK_t_user_status_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_token_type",
                columns: table => new
                {
                    user_token_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    code = table.Column<string>(type: "NVARCHAR2(128)", maxLength: 128, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_token_type", x => x.user_token_type_id);
                    table.ForeignKey(
                        name: "FK_t_user_token_type_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    username = table.Column<string>(type: "NVARCHAR2(320)", maxLength: 320, nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    user_status_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_t_user_status_user_status_id",
                        column: x => x.user_status_id,
                        principalTable: "t_user_status",
                        principalColumn: "user_status_id");
                    table.ForeignKey(
                        name: "FK_t_user_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_user_attribute",
                columns: table => new
                {
                    user_attribute_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    user_attribute_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    string_value = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    int16_value = table.Column<short>(type: "NUMBER(5)", nullable: true),
                    int32_value = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    int64_value = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    float_value = table.Column<float>(type: "BINARY_FLOAT", nullable: true),
                    decimal_value = table.Column<decimal>(type: "DECIMAL(20,2)", precision: 20, scale: 2, nullable: true),
                    double_value = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    datetime_value = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    boolean_value = table.Column<bool>(type: "BOOLEAN", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_attribute", x => x.user_attribute_id);
                    table.ForeignKey(
                        name: "FK_t_user_attribute_t_user_attribute_type_user_attribute_type_id",
                        column: x => x.user_attribute_type_id,
                        principalTable: "t_user_attribute_type",
                        principalColumn: "user_attribute_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_attribute_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_credential",
                columns: table => new
                {
                    user_credential_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    user_credential_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    password_salt = table.Column<byte[]>(type: "RAW(512)", maxLength: 512, nullable: false),
                    password_hash = table.Column<byte[]>(type: "RAW(512)", maxLength: 512, nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    is_expired = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_credential", x => x.user_credential_id);
                    table.ForeignKey(
                        name: "FK_t_user_credential_t_user_credential_type_user_credential_type_id",
                        column: x => x.user_credential_type_id,
                        principalTable: "t_user_credential_type",
                        principalColumn: "user_credential_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_credential_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_email",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    email_address = table.Column<string>(type: "NVARCHAR2(320)", maxLength: 320, nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    is_verified = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    verified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_email", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_email_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_email_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_group_user",
                columns: table => new
                {
                    user_group_user_id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    user_group_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_group_user", x => x.user_group_user_id);
                    table.ForeignKey(
                        name: "FK_t_user_group_user_t_user_group_user_group_id",
                        column: x => x.user_group_id,
                        principalTable: "t_user_group",
                        principalColumn: "user_group_id");
                    table.ForeignKey(
                        name: "FK_t_user_group_user_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_phone",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    user_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    phone_number = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    modified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    is_verified = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    verified_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_phone", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_phone_t_user_type_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "t_user_type",
                        principalColumn: "user_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_phone_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_session",
                columns: table => new
                {
                    user_session_id = table.Column<byte[]>(type: "RAW(64)", maxLength: 64, nullable: false),
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    session_secret_salt = table.Column<byte[]>(type: "RAW(512)", maxLength: 512, nullable: false),
                    session_secret_hash = table.Column<byte[]>(type: "RAW(512)", maxLength: 512, nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    is_expired = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_session", x => x.user_session_id);
                    table.ForeignKey(
                        name: "FK_t_user_session_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "t_user_token",
                columns: table => new
                {
                    user_token_id = table.Column<byte[]>(type: "RAW(64)", maxLength: 64, nullable: false),
                    user_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    user_token_type_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    token_secret_salt = table.Column<byte[]>(type: "RAW(512)", maxLength: 512, nullable: false),
                    token_secret_hash = table.Column<byte[]>(type: "RAW(512)", maxLength: 512, nullable: false),
                    created_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    is_expired = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    is_consumed = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    consumed_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_token", x => x.user_token_id);
                    table.ForeignKey(
                        name: "FK_t_user_token_t_user_token_type_user_token_type_id",
                        column: x => x.user_token_type_id,
                        principalTable: "t_user_token_type",
                        principalColumn: "user_token_type_id");
                    table.ForeignKey(
                        name: "FK_t_user_token_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id");
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
                name: "IX_t_user_attribute_user_attribute_type_id",
                table: "t_user_attribute",
                column: "user_attribute_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_user_id",
                table: "t_user_attribute",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_type_code",
                table: "t_user_attribute_type",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_type_created_date",
                table: "t_user_attribute_type",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_type_modified_date",
                table: "t_user_attribute_type",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_type_user_type_id",
                table: "t_user_attribute_type",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_type_user_type_id_code",
                table: "t_user_attribute_type",
                columns: new[] { "user_type_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_attribute_type_value_type",
                table: "t_user_attribute_type",
                column: "value_type");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_created_date",
                table: "t_user_credential",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_expiry_date",
                table: "t_user_credential",
                column: "expiry_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_is_expired",
                table: "t_user_credential",
                column: "is_expired");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_modified_date",
                table: "t_user_credential",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_user_credential_type_id",
                table: "t_user_credential",
                column: "user_credential_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_user_id",
                table: "t_user_credential",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_user_id_user_credential_type_id",
                table: "t_user_credential",
                columns: new[] { "user_id", "user_credential_type_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_type_code",
                table: "t_user_credential_type",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_type_created_date",
                table: "t_user_credential_type",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_type_modified_date",
                table: "t_user_credential_type",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_type_user_type_id",
                table: "t_user_credential_type",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_credential_type_user_type_id_code",
                table: "t_user_credential_type",
                columns: new[] { "user_type_id", "code" },
                unique: true);

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
                name: "IX_t_user_group_code",
                table: "t_user_group",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_created_date",
                table: "t_user_group",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_modified_date",
                table: "t_user_group",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_user_type_id",
                table: "t_user_group",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_user_type_id_code",
                table: "t_user_group",
                columns: new[] { "user_type_id", "code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_user_user_group_id",
                table: "t_user_group_user",
                column: "user_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_user_user_group_id_user_id",
                table: "t_user_group_user",
                columns: new[] { "user_group_id", "user_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_group_user_user_id",
                table: "t_user_group_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_phone_user_type_id",
                table: "t_user_phone",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_code",
                table: "t_user_scope",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_created_date",
                table: "t_user_scope",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_modified_date",
                table: "t_user_scope",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_alias_code",
                table: "t_user_scope_alias",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_alias_created_date",
                table: "t_user_scope_alias",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_alias_modified_date",
                table: "t_user_scope_alias",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_scope_alias_user_scope_id",
                table: "t_user_scope_alias",
                column: "user_scope_id");

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
                name: "IX_t_user_status_code",
                table: "t_user_status",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_status_created_date",
                table: "t_user_status",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_status_modified_date",
                table: "t_user_status",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_status_user_type_id",
                table: "t_user_status",
                column: "user_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_status_user_type_id_code",
                table: "t_user_status",
                columns: new[] { "user_type_id", "code" },
                unique: true);

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
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_created_date",
                table: "t_user_type",
                column: "created_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_modified_date",
                table: "t_user_type",
                column: "modified_date");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_user_scope_id",
                table: "t_user_type",
                column: "user_scope_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_type_user_scope_id_code",
                table: "t_user_type",
                columns: new[] { "user_scope_id", "code" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_user_attribute");

            migrationBuilder.DropTable(
                name: "t_user_credential");

            migrationBuilder.DropTable(
                name: "t_user_email");

            migrationBuilder.DropTable(
                name: "t_user_group_user");

            migrationBuilder.DropTable(
                name: "t_user_phone");

            migrationBuilder.DropTable(
                name: "t_user_scope_alias");

            migrationBuilder.DropTable(
                name: "t_user_session");

            migrationBuilder.DropTable(
                name: "t_user_token");

            migrationBuilder.DropTable(
                name: "t_user_attribute_type");

            migrationBuilder.DropTable(
                name: "t_user_credential_type");

            migrationBuilder.DropTable(
                name: "t_user_group");

            migrationBuilder.DropTable(
                name: "t_user_token_type");

            migrationBuilder.DropTable(
                name: "t_user");

            migrationBuilder.DropTable(
                name: "t_user_status");

            migrationBuilder.DropTable(
                name: "t_user_type");

            migrationBuilder.DropTable(
                name: "t_user_scope");
        }
    }
}

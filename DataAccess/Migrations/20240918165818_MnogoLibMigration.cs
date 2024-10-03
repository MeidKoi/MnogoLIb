using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class MnogoLibMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author_Status",
                columns: table => new
                {
                    id_author_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_author_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Author_Status_id_author_status", x => x.id_author_status);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id_author = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_author = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Authors_id_author", x => x.id_author);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_category = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Categories_id_category", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id_genre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_genre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Genres_id_genre", x => x.id_genre);
                });

            migrationBuilder.CreateTable(
                name: "Group_Materials",
                columns: table => new
                {
                    id_group = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_group = table.Column<string>(type: "varchar(115)", unicode: false, maxLength: 115, nullable: false),
                    description_group = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Materials", x => x.id_group);
                });

            migrationBuilder.CreateTable(
                name: "Message_Status",
                columns: table => new
                {
                    id_message_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_message_status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Message_Status_id_message_status", x => x.id_message_status);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    id_payment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    card_number = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    cvv = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false),
                    expression_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.id_payment);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_role = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Roles_id_role", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "User_Status",
                columns: table => new
                {
                    id_user_status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_user_status = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_User_Status_id_user_status", x => x.id_user_status);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email_user = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password_user = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nickname_user = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_by = table.Column<int>(type: "int", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Users_id_user", x => x.id_user);
                    table.ForeignKey(
                        name: "fk_Roles_Users_0",
                        column: x => x.id_role,
                        principalTable: "Roles",
                        principalColumn: "id_role");
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    id_chat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_owner = table.Column<int>(type: "int", nullable: false),
                    name_chat = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_by = table.Column<int>(type: "int", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Chat_id_chat", x => x.id_chat);
                    table.ForeignKey(
                        name: "FK__Chat__deleted_by__1CDC41A7",
                        column: x => x.deleted_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK__Chat__last_updat__1BE81D6E",
                        column: x => x.last_update_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "fk_Users_Chat_0",
                        column: x => x.id_owner,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id_comment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text_comment = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Comments_id_comment", x => x.id_comment);
                    table.ForeignKey(
                        name: "fk_Users_Comments_0",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    id_file = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_file = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    path_file = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_by = table.Column<int>(type: "int", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Files_id_file", x => x.id_file);
                    table.ForeignKey(
                        name: "FK__Files__deleted_b__2665ABE1",
                        column: x => x.deleted_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK__Files__deleted_t__247D636F",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK__Files__last_upda__257187A8",
                        column: x => x.last_update_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Payment_Users",
                columns: table => new
                {
                    id_payment = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Users", x => new { x.id_payment, x.id_user });
                    table.ForeignKey(
                        name: "Relationship31",
                        column: x => x.id_payment,
                        principalTable: "Payment",
                        principalColumn: "id_payment");
                    table.ForeignKey(
                        name: "Relationship32",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Chat_Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_chat = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat_Users", x => new { x.id_user, x.id_chat });
                    table.ForeignKey(
                        name: "FK__Chat_User__delet__2B2A60FE",
                        column: x => x.deleted_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "Relationship21",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "Relationship22",
                        column: x => x.id_chat,
                        principalTable: "Chat",
                        principalColumn: "id_chat");
                    table.ForeignKey(
                        name: "Relationship25",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Messages_User",
                columns: table => new
                {
                    id_message = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_chat = table.Column<int>(type: "int", nullable: false),
                    deliver_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_message_status = table.Column<int>(type: "int", nullable: false),
                    text_message = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Messages_User_id_message", x => x.id_message);
                    table.ForeignKey(
                        name: "FK__Messages___delet__21A0F6C4",
                        column: x => x.deleted_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "fk_Chat_Messages_User_1",
                        column: x => x.id_chat,
                        principalTable: "Chat",
                        principalColumn: "id_chat");
                    table.ForeignKey(
                        name: "fk_Message_Status_Messages_User_2",
                        column: x => x.id_message_status,
                        principalTable: "Message_Status",
                        principalColumn: "id_message_status");
                    table.ForeignKey(
                        name: "fk_Users_Messages_User_0",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Comment_Rates",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_comment = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment_Rates", x => new { x.id_user, x.id_comment });
                    table.ForeignKey(
                        name: "Relationship23",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "Relationship24",
                        column: x => x.id_comment,
                        principalTable: "Comments",
                        principalColumn: "id_comment");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_material = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    description_material = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    id_category = table.Column<int>(type: "int", nullable: false),
                    id_author_status = table.Column<int>(type: "int", nullable: false),
                    id_author = table.Column<int>(type: "int", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_by = table.Column<int>(type: "int", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_by = table.Column<int>(type: "int", nullable: true),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    file_icon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Materials_id_material", x => x.id_material);
                    table.ForeignKey(
                        name: "FK__Materials__creat__0D99FE17",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK__Materials__delet__0F824689",
                        column: x => x.deleted_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK__Materials__last___0E8E2250",
                        column: x => x.last_update_by,
                        principalTable: "Users",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "fk_Author_Status_Materials_2",
                        column: x => x.id_author_status,
                        principalTable: "Author_Status",
                        principalColumn: "id_author_status");
                    table.ForeignKey(
                        name: "fk_Authors_Materials_1",
                        column: x => x.id_author,
                        principalTable: "Authors",
                        principalColumn: "id_author");
                    table.ForeignKey(
                        name: "fk_Categories_Materials_0",
                        column: x => x.id_category,
                        principalTable: "Categories",
                        principalColumn: "id_category");
                    table.ForeignKey(
                        name: "Relationship26",
                        column: x => x.file_icon,
                        principalTable: "Files",
                        principalColumn: "id_file");
                });

            migrationBuilder.CreateTable(
                name: "Comment_Material",
                columns: table => new
                {
                    id_comment = table.Column<int>(type: "int", nullable: false),
                    id_material = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Comment_Material_0", x => new { x.id_comment, x.id_material });
                    table.ForeignKey(
                        name: "fk_Comments_Comment_Material_1",
                        column: x => x.id_comment,
                        principalTable: "Comments",
                        principalColumn: "id_comment");
                    table.ForeignKey(
                        name: "fk_Materials_Comment_Material_2",
                        column: x => x.id_material,
                        principalTable: "Materials",
                        principalColumn: "id_material");
                });

            migrationBuilder.CreateTable(
                name: "Material_File",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false),
                    id_file = table.Column<int>(type: "int", nullable: false),
                    volume = table.Column<int>(type: "int", nullable: true),
                    chapter = table.Column<int>(type: "int", nullable: false),
                    frame_number = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Material_File_0", x => new { x.id_material, x.id_file });
                    table.ForeignKey(
                        name: "fk_Files_Material_File_2",
                        column: x => x.id_file,
                        principalTable: "Files",
                        principalColumn: "id_file");
                    table.ForeignKey(
                        name: "fk_Materials_Material_File_1",
                        column: x => x.id_material,
                        principalTable: "Materials",
                        principalColumn: "id_material");
                });

            migrationBuilder.CreateTable(
                name: "Materials_Genres",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false),
                    id_genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Materials_Genres_0", x => new { x.id_material, x.id_genre });
                    table.ForeignKey(
                        name: "fk_Genres_Materials_Genres_2",
                        column: x => x.id_genre,
                        principalTable: "Genres",
                        principalColumn: "id_genre");
                    table.ForeignKey(
                        name: "fk_Materials_Materials_Genres_1",
                        column: x => x.id_material,
                        principalTable: "Materials",
                        principalColumn: "id_material");
                });

            migrationBuilder.CreateTable(
                name: "Materials_User_Status",
                columns: table => new
                {
                    id_material = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_user_status = table.Column<int>(type: "int", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Materials_User_Status_0", x => new { x.id_material, x.id_user, x.id_user_status });
                    table.ForeignKey(
                        name: "fk_Materials_Materials_User_Status_2",
                        column: x => x.id_material,
                        principalTable: "Materials",
                        principalColumn: "id_material");
                    table.ForeignKey(
                        name: "fk_User_Status_Materials_User_Status_3",
                        column: x => x.id_user_status,
                        principalTable: "User_Status",
                        principalColumn: "id_user_status");
                    table.ForeignKey(
                        name: "fk_Users_Materials_User_Status_1",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    id_rate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_material = table.Column<int>(type: "int", nullable: false),
                    value_rate = table.Column<byte>(type: "tinyint", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    last_update_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_Rates_id_rate", x => x.id_rate);
                    table.ForeignKey(
                        name: "fk_Materials_Rates_1",
                        column: x => x.id_material,
                        principalTable: "Materials",
                        principalColumn: "id_material");
                    table.ForeignKey(
                        name: "fk_Users_Rates_0",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Related_materials",
                columns: table => new
                {
                    id_group = table.Column<int>(type: "int", nullable: false),
                    id_material = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Related_materials", x => new { x.id_group, x.id_material });
                    table.ForeignKey(
                        name: "Relationship29",
                        column: x => x.id_group,
                        principalTable: "Group_Materials",
                        principalColumn: "id_group");
                    table.ForeignKey(
                        name: "Relationship30",
                        column: x => x.id_material,
                        principalTable: "Materials",
                        principalColumn: "id_material");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_deleted_by",
                table: "Chat",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_id_owner",
                table: "Chat",
                column: "id_owner");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_last_update_by",
                table: "Chat",
                column: "last_update_by");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Users_deleted_by",
                table: "Chat_Users",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Users_id_chat",
                table: "Chat_Users",
                column: "id_chat");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship25",
                table: "Chat_Users",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Material_id_material",
                table: "Comment_Material",
                column: "id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Rates_id_comment",
                table: "Comment_Rates",
                column: "id_comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_id_user",
                table: "Comments",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Files_created_by",
                table: "Files",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Files_deleted_by",
                table: "Files",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Files_last_update_by",
                table: "Files",
                column: "last_update_by");

            migrationBuilder.CreateIndex(
                name: "IX_Material_File_id_file",
                table: "Material_File",
                column: "id_file");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_created_by",
                table: "Materials",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_deleted_by",
                table: "Materials",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_id_author",
                table: "Materials",
                column: "id_author");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_id_author_status",
                table: "Materials",
                column: "id_author_status");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_id_category",
                table: "Materials",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_last_update_by",
                table: "Materials",
                column: "last_update_by");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship26",
                table: "Materials",
                column: "file_icon");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Genres_id_genre",
                table: "Materials_Genres",
                column: "id_genre");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_User_Status_id_user",
                table: "Materials_User_Status",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_User_Status_id_user_status",
                table: "Materials_User_Status",
                column: "id_user_status");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_User_deleted_by",
                table: "Messages_User",
                column: "deleted_by");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_User_id_chat",
                table: "Messages_User",
                column: "id_chat");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_User_id_message_status",
                table: "Messages_User",
                column: "id_message_status");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_User_id_user",
                table: "Messages_User",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Users_id_user",
                table: "Payment_Users",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_id_material",
                table: "Rates",
                column: "id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_id_user",
                table: "Rates",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Related_materials_id_material",
                table: "Related_materials",
                column: "id_material");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_role",
                table: "Users",
                column: "id_role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat_Users");

            migrationBuilder.DropTable(
                name: "Comment_Material");

            migrationBuilder.DropTable(
                name: "Comment_Rates");

            migrationBuilder.DropTable(
                name: "Material_File");

            migrationBuilder.DropTable(
                name: "Materials_Genres");

            migrationBuilder.DropTable(
                name: "Materials_User_Status");

            migrationBuilder.DropTable(
                name: "Messages_User");

            migrationBuilder.DropTable(
                name: "Payment_Users");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Related_materials");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "User_Status");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Message_Status");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Group_Materials");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Author_Status");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
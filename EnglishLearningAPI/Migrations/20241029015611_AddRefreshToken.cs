using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishLearningAPI.Migrations
{
    public partial class AddRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Progresses");

            migrationBuilder.DropTable(
                name: "Vocabularys");

            migrationBuilder.AlterColumn<string>(
                name: "subscription_plan",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "Users",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "refresh_token_expiry",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "topic_name",
                table: "Topics",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "plan",
                table: "Subscriptions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                table: "Payments",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "payment_date",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "course_name",
                table: "Courses",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Vocabularies",
                columns: table => new
                {
                    vocab_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    word = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    meaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    example_sentence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    topic_id = table.Column<int>(type: "int", nullable: false),
                    pronunciation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabularies", x => x.vocab_id);
                    table.ForeignKey(
                        name: "FK_Vocabularies_Topics_topic_id",
                        column: x => x.topic_id,
                        principalTable: "Topics",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProgresses",
                columns: table => new
                {
                    progress_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    vocab_id = table.Column<int>(type: "int", nullable: false),
                    review_interval = table.Column<int>(type: "int", nullable: false),
                    last_reviewed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    next_review = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgresses", x => x.progress_id);
                    table.ForeignKey(
                        name: "FK_UserProgresses_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgresses_Vocabularies_vocab_id",
                        column: x => x.vocab_id,
                        principalTable: "Vocabularies",
                        principalColumn: "vocab_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_course_id",
                table: "Topics",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_user_id",
                table: "Subscriptions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_user_id",
                table: "Payments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_user_id",
                table: "UserProgresses",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProgresses_vocab_id",
                table: "UserProgresses",
                column: "vocab_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_topic_id",
                table: "Vocabularies",
                column: "topic_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_user_id",
                table: "Payments",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_user_id",
                table: "Subscriptions",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Courses_course_id",
                table: "Topics",
                column: "course_id",
                principalTable: "Courses",
                principalColumn: "course_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_user_id",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_user_id",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_course_id",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "UserProgresses");

            migrationBuilder.DropTable(
                name: "Vocabularies");

            migrationBuilder.DropIndex(
                name: "IX_Topics_course_id",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_user_id",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Payments_user_id",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "refresh_token_expiry",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "subscription_plan",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "topic_name",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "Subscriptions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "plan",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "Subscriptions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "payment_method",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "payment_date",
                table: "Payments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "course_name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "User_Progresses",
                columns: table => new
                {
                    progress_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_reviewed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    next_review = table.Column<DateTime>(type: "datetime2", nullable: true),
                    review_interval = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    vocab_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Progresses", x => x.progress_id);
                });

            migrationBuilder.CreateTable(
                name: "Vocabularys",
                columns: table => new
                {
                    vocab_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    example_sentence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    meaning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pronunciation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    topic_id = table.Column<int>(type: "int", nullable: false),
                    word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabularys", x => x.vocab_id);
                });
        }
    }
}

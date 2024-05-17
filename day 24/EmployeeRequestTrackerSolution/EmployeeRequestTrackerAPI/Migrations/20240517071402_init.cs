using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestRaisedBy = table.Column<int>(type: "int", nullable: false),
                    RequestClosedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestNumber);
                    table.ForeignKey(
                        name: "FK_Request_Employees_RequestClosedBy",
                        column: x => x.RequestClosedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Employees_RequestRaisedBy",
                        column: x => x.RequestRaisedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestSolution",
                columns: table => new
                {
                    SolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    SolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolvedBy = table.Column<int>(type: "int", nullable: false),
                    SolvedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSolved = table.Column<bool>(type: "bit", nullable: false),
                    RequestRaiserComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionFeedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestSolution", x => x.SolutionId);
                    table.ForeignKey(
                        name: "FK_RequestSolution_Employees_SolvedBy",
                        column: x => x.SolvedBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestSolution_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolutionFeedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: false),
                    FeedbackBy = table.Column<int>(type: "int", nullable: false),
                    FeedbackDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionFeedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_SolutionFeedback_Employees_FeedbackBy",
                        column: x => x.FeedbackBy,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolutionFeedback_RequestSolution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "RequestSolution",
                        principalColumn: "SolutionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestClosedBy",
                table: "Request",
                column: "RequestClosedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestRaisedBy",
                table: "Request",
                column: "RequestRaisedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolution_RequestId",
                table: "RequestSolution",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestSolution_SolvedBy",
                table: "RequestSolution",
                column: "SolvedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedback_FeedbackBy",
                table: "SolutionFeedback",
                column: "FeedbackBy");

            migrationBuilder.CreateIndex(
                name: "IX_SolutionFeedback_SolutionId",
                table: "SolutionFeedback",
                column: "SolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolutionFeedback");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RequestSolution");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

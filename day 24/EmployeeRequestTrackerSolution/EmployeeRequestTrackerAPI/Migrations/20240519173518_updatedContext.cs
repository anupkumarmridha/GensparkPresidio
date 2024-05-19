using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class updatedContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employees_RequestClosedBy",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Employees_RequestRaisedBy",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolution_Request_RequestId",
                table: "RequestSolution");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackBy",
                table: "SolutionFeedback");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedback_RequestSolution_SolutionId",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Request",
                table: "Request");

            migrationBuilder.RenameTable(
                name: "SolutionFeedback",
                newName: "SolutionFeedbacks");

            migrationBuilder.RenameTable(
                name: "RequestSolution",
                newName: "RequestSolutions");

            migrationBuilder.RenameTable(
                name: "Request",
                newName: "Requests");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_SolutionId",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedback_FeedbackBy",
                table: "SolutionFeedbacks",
                newName: "IX_SolutionFeedbacks_FeedbackBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_SolvedBy",
                table: "RequestSolutions",
                newName: "IX_RequestSolutions_SolvedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolution_RequestId",
                table: "RequestSolutions",
                newName: "IX_RequestSolutions_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestRaisedBy",
                table: "Requests",
                newName: "IX_Requests_RequestRaisedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Request_RequestClosedBy",
                table: "Requests",
                newName: "IX_Requests_RequestClosedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks",
                column: "FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolutions",
                table: "RequestSolutions",
                column: "SolutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests",
                column: "RequestRaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackBy",
                table: "SolutionFeedbacks",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks",
                column: "SolutionId",
                principalTable: "RequestSolutions",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestClosedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestRaisedBy",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Employees_SolvedBy",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestSolutions_Requests_RequestId",
                table: "RequestSolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_Employees_FeedbackBy",
                table: "SolutionFeedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolutionFeedbacks_RequestSolutions_SolutionId",
                table: "SolutionFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolutionFeedbacks",
                table: "SolutionFeedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestSolutions",
                table: "RequestSolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "SolutionFeedbacks",
                newName: "SolutionFeedback");

            migrationBuilder.RenameTable(
                name: "RequestSolutions",
                newName: "RequestSolution");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "Request");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_SolutionId",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_SolutionFeedbacks_FeedbackBy",
                table: "SolutionFeedback",
                newName: "IX_SolutionFeedback_FeedbackBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolutions_SolvedBy",
                table: "RequestSolution",
                newName: "IX_RequestSolution_SolvedBy");

            migrationBuilder.RenameIndex(
                name: "IX_RequestSolutions_RequestId",
                table: "RequestSolution",
                newName: "IX_RequestSolution_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestRaisedBy",
                table: "Request",
                newName: "IX_Request_RequestRaisedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Requests_RequestClosedBy",
                table: "Request",
                newName: "IX_Request_RequestClosedBy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolutionFeedback",
                table: "SolutionFeedback",
                column: "FeedbackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestSolution",
                table: "RequestSolution",
                column: "SolutionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Request",
                table: "Request",
                column: "RequestNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employees_RequestClosedBy",
                table: "Request",
                column: "RequestClosedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Employees_RequestRaisedBy",
                table: "Request",
                column: "RequestRaisedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Employees_SolvedBy",
                table: "RequestSolution",
                column: "SolvedBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestSolution_Request_RequestId",
                table: "RequestSolution",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "RequestNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_Employees_FeedbackBy",
                table: "SolutionFeedback",
                column: "FeedbackBy",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolutionFeedback_RequestSolution_SolutionId",
                table: "SolutionFeedback",
                column: "SolutionId",
                principalTable: "RequestSolution",
                principalColumn: "SolutionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class addedFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Expensecategoryid",
                table: "Expense",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Expense_Expensecategoryid",
                table: "Expense",
                column: "Expensecategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Categories_Expensecategoryid",
                table: "Expense",
                column: "Expensecategoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Categories_Expensecategoryid",
                table: "Expense");

            migrationBuilder.DropIndex(
                name: "IX_Expense_Expensecategoryid",
                table: "Expense");

            migrationBuilder.DropColumn(
                name: "Expensecategoryid",
                table: "Expense");
        }
    }
}

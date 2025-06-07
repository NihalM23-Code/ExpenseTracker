using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.Migrations
{
    /// <inheritdoc />
    public partial class correectionformodelbinding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Categories_Expensecategoryid",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "Expensecategoryid",
                table: "Expense",
                newName: "ExpenseCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_Expensecategoryid",
                table: "Expense",
                newName: "IX_Expense_ExpenseCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Categories_ExpenseCategoryId",
                table: "Expense",
                column: "ExpenseCategoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Categories_ExpenseCategoryId",
                table: "Expense");

            migrationBuilder.RenameColumn(
                name: "ExpenseCategoryId",
                table: "Expense",
                newName: "Expensecategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ExpenseCategoryId",
                table: "Expense",
                newName: "IX_Expense_Expensecategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Categories_Expensecategoryid",
                table: "Expense",
                column: "Expensecategoryid",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

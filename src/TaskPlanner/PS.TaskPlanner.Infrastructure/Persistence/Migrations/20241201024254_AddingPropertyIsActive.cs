using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS.TaskPlanner.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingPropertyIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AppUsers");
        }
    }
}

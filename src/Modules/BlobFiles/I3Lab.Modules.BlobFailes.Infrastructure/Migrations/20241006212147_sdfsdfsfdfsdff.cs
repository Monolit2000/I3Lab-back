using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace I3Lab.Modules.BlobFailes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sdfsdfsfdfsdff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blobFile");

            migrationBuilder.RenameTable(
                name: "BlobFiles",
                newName: "BlobFiles",
                newSchema: "blobFile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "BlobFiles",
                schema: "blobFile",
                newName: "BlobFiles");
        }
    }
}

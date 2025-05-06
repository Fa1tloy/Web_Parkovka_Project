using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_Parkovka_Project.Migrations
{
    /// <inheritdoc />
    public partial class Login : Migration
    {
        public ClaimsIdentity User { get; internal set; }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

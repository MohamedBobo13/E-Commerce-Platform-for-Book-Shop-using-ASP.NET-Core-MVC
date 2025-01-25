using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.DBInitializer
{

    // Implements the IDBInitializer interface to handle database initialization tasks.

    public class DBInitializer : IDBInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;


        // Constructor for dependency injection.

        public DBInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        /// <summary>
        /// Initializes the database by applying migrations, creating roles, and creating a default admin user.
        /// </summary>
        public void Initialize()
        {
            // Apply any pending migrations
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Handle migration exceptions (log or rethrow if needed)
            }

            // Check if roles exist; if not, create them
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
            {
                // Create predefined roles
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

                // Create a default admin user
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin@gmail.com",
                    Email = "Admin@gmail.com",
                    Name = "Mohamed Bobo",
                    PhoneNumber = "1234567890",
                    StreetAddress = "test 123 Ave",
                    State = "IL",
                    PostalCode = "123456",
                    City = "Cairo"
                }, "Admin123*").GetAwaiter().GetResult();

                // Assign the admin user to the Admin role
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Admin@gmail.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;
        }
    }
}

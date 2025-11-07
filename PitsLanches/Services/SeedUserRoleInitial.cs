using Microsoft.AspNetCore.Identity;

namespace PitsLanches.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            {
                if (_userManager.FindByEmailAsync("usuario@gmail.com").Result == null)
                {
                    IdentityUser user = new IdentityUser();
                    user.UserName = "usuario@gmail.com";
                    user.Email = "usuario@gmail.com";
                    user.NormalizedUserName = "USUARIO@GMAIL.COM";
                    user.NormalizedEmail = "USUARIO@GMAIL.COM";
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.SecurityStamp = Guid.NewGuid().ToString();

                    IdentityResult result = _userManager.CreateAsync(user, "1Qaz2wsx!").Result;

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "Member").Wait();
                    }
                }

                if (_userManager.FindByEmailAsync("admin@gmail.com").Result == null)
                {
                    IdentityUser user = new IdentityUser();
                    user.UserName = "admin@gmail.com";
                    user.Email = "admin@gmail.com";
                    user.NormalizedUserName = "ADMIN@GMAIL.COM";
                    user.NormalizedEmail = "ADMIN@GMAIL.COM";
                    user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.SecurityStamp = Guid.NewGuid().ToString();

                    IdentityResult result = _userManager.CreateAsync(user, "1Qaz2wsx!").Result;

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
            }

        }
    }
}

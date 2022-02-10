using CleanSuporte.Infra.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using CleanSuporte;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Infra.Data.Context
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        public void Initialize()
        {


        }
    }
}

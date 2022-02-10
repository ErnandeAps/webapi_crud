using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Infra.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Cidade { get; set; }
        public string Uf { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concreate
{
    public class User: IdentityUser<int>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

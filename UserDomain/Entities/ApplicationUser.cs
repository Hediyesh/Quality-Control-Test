using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain.Entities
{
    public class ApplicationUser: IdentityUser
    {
        [MaxLength(450)]
        public string FirstName { get; set; }
        [MaxLength(450)]
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
        public ICollection<Person>? Persons { get; set; }
    }
}

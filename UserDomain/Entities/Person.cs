using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain.Entities
{
    public class Person
    {
        [Key]
        [MaxLength(450)]
        public string PersonId { get; set; } = Guid.NewGuid().ToString(); 
        [MaxLength(450)]
        public string FirstName { get; set; }
        [MaxLength(450)]
        public string LastName { get; set; }
        [MaxLength(450)]
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZwartOpWit.Models
{
    public class User
    {
        public User()
        {
            Stitches = new List<Stitch>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Username { get; set; }


        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Email { get; set; }

        public List<Stitch> Stitches { get; set; }
    }
}

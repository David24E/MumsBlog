using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MumsBlog.Models
{
    public class BlogCategory
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}

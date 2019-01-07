using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumsBlog.Models
{
    public class BlogPost
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string PostTitle { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public String DateAdded { get; set; }

        public string UserId { get; set; }

        //public int CategoryId { get; set; }



        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("CategoryId")]
        //public virtual BlogCategory BlogCategory { get; set; }
    }
}

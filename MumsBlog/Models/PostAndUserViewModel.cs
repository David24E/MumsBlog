using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MumsBlog.Models
{
    public class PostAndUserViewModel
    {

        public ApplicationUser UserObj { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }

    }
}

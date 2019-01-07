using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MumsBlog.Models
{
    public class IndividualButtonPartial
    {

        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Fa { get; set; }
        public string Text { get; set; }

        public int? CategoryId { get; set; }
        public string CustomerId { get; set; }
        public int? BlogPostId { get; set; }

        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (CategoryId != 0 && CategoryId != null)
                {
                    param.Append(String.Format("{0}", CategoryId));
                }
                if (CustomerId != null && CustomerId.Length > 0)
                {
                    param.Append(String.Format("{0}", CustomerId));
                }
                if (BlogPostId != 0 && BlogPostId != null)
                {
                    param.Append(String.Format("{0}", BlogPostId));
                }
                return param.ToString().Substring(0, param.Length);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTesteUnitario.Models
{
    public class Articles : List<Article>
    {
    }

    public class Article
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Contents { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

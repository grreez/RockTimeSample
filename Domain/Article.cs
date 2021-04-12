using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Domain
{
    public class Article
    {
        public Article()
        {
            this.Articles = new List<Article>();
        }
        [Key]
        public int ArticleId { get; set; }

        public int? ParentArticleId { get; set; }
        [ForeignKey("ParentArticleId")]
        public Article ParentArticle { get; set; }

        [Required]
        public int ArticleLevel { get; set; }

        [MaxLength(50), Required]
        public string ArticleTitle { get; set; }
        [MaxLength(50)]
        public string ArticleHeader { get; set; }
        [Column(TypeName = "text")]
        public string ArticleContent { get; set; }

        [InverseProperty("ParentArticle")]
        public ICollection<Article> Articles { get; set; }

    }
}

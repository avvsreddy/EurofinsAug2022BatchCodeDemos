using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubProtal2022.Models.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Url { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CatagoryID { get; set; }
        public virtual Catagory Catagory { get; set; }
        public bool IsApproved { get; set; }
        public string PostedBy { get; set; }
        public DateTime DateSubmited { get; set; }

    }
}
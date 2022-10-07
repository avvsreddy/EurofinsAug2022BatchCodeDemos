﻿using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubProtal2022.Models.Entities
{
    public class Catagory
    {
        public int CatagoryID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
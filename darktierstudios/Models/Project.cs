using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace darktierstudios.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [MaxLength(150)]
        [Required]
        public string Slug { get; set; }

        [MaxLength(150)]
        [Required]
        public string Author { get; set; }

        [MaxLength(250)]
        [Required]
        public string Synopsis { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public string Rulebook { get; set; }
        public string Charactersheet { get; set; }
        public string Document { get; set; }
        
        public Guid TheGameCrafterApiID { get; set; }
        public Guid TheGameCrafterCartID { get; set; }

        public bool InDevelopment { get; set; }
        public bool Incomplete { get; set; }

        public DateTime ProjectDate { get; set; }
    }
}
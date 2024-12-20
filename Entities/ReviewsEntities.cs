using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Entities
{
    public class ReviewsEntities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(50)]
        public string Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ClientId { get; set; }

        public virtual ClientsEntities Client { get; set; }

        [Required]
        public int LawyerId { get; set; }

        public virtual LawyersEntities Lawyer { get; set; }
    }
}
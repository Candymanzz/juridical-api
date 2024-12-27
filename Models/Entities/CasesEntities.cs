using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class CasesEntities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CaseName { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime OpeningDate { get; set; }

        [Required]
        public int ClientId { get; set; }

        public virtual ClientsEntities Client { get; set; }

        [Required]
        public int LawyerId { get; set; }

        public virtual LawyersEntities Lawyer { get; set; }
    }
}
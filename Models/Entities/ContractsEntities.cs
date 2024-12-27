using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class ContractsEntities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime SigningDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }


        [Required]
        public int ClientId { get; set; }

        public virtual ClientsEntities Client { get; set; }

        [Required]
        public int LawyerId { get; set; }

        public virtual LawyersEntities Lawyer { get; set; }
    }
}
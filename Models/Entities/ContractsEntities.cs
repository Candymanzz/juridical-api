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
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SigningDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }


        [Required]
        public Guid ClientId { get; set; }

        public ClientsEntities? Client { get; set; }

        [Required]
        public Guid LawyerId { get; set; }

        public LawyersEntities? Lawyer { get; set; }
    }
}
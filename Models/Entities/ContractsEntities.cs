using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public ClientsEntities? Client { get; set; }

        [Required]
        public Guid LawyerId { get; set; }
        [JsonIgnore]
        public LawyersEntities? Lawyer { get; set; }
    }
}
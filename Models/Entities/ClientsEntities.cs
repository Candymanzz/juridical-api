using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class ClientsEntities
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;

        //FK

        [JsonIgnore]
        public ReviewsEntities? Review { get; set; }
        [JsonIgnore]
        public PaymentsEntities? Payment { get; set; }
        [JsonIgnore]
        public CasesEntities? Case { get; set; }
        [JsonIgnore]
        public ContractsEntities? Contract { get; set; }
    }
}
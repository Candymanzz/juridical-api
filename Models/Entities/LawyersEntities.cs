using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace juridical_api.Models.Entities
{
    public class LawyersEntities
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
        [StringLength(25)]
        public string Specialization { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        //FK
        [JsonIgnore]
        public ContractsEntities? Contract { get; set; }
        [JsonIgnore]
        public TasksEntities? Task { get; set; }
        [JsonIgnore]
        public ReviewsEntities? Review { get; set; }
        [JsonIgnore]
        public CasesEntities? Case { get; set; }
    }
}
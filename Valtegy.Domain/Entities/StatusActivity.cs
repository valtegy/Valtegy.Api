using System;
using System.ComponentModel.DataAnnotations;

namespace Valtegy.Domain.Entities
{
    public class StatusActivity
    {
        [Required]
        public Guid Id { get; set; }

        [Key]
        [Required]
        public int StatusActivityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Valtegy.Domain.Entities
{
    public class Activities : AuditBase
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTimeOffset ActivityDate { get; set; }
        public string Name { get; set; }
        public int ActivityTypeId { get; set; }
        public int ActivityNumber { get; set; }
        public int StatusActivityId { get; set; }
        public double Hours { get; set; }
        public string Comments { get; set; }
        public DateTimeOffset InsertDate { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

    }
}

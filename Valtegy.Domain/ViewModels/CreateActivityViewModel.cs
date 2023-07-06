using System;

namespace Valtegy.Domain.ViewModels
{
    public class CreateActivityViewModel
    {
        public Guid Id { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Name { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityType { get; set; }
        public int ActivityNumber { get; set; }
        public int StatusActivityId { get; set; }
        public string StatusActivity { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string Comments { get; set; }
    }
}

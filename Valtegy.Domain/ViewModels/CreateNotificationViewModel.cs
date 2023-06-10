using System;

namespace Valtegy.Domain.ViewModels
{
    public class CreateNotificationViewModel
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string Cco { get; set; }
        public string Subject { get; set; }
        public string BobyMessage { get; set; }
        public int Type { get; set; }
        public bool IsBodyHtml { get; set; }
        public Guid ReferenceId { get; set; }
        public string Link { get; set; }
        public string CategoryName { get; set; }
        public string From { get; set; }
    }
}

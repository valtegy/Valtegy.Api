using System;

namespace Valtegy.Domain.Entities
{
    public class Notification : AuditBase
    {
        public Guid Id { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Cco { get; set; }
        public string Subject { get; set; }
        public string BobyMessage { get; set; }
        public int Type { get; set; }
        public bool IsBodyHtml { get; set; }        
        public int Status { get; set; }
        public string Error { get; set; }
        public bool IsReaded { get; set; }
        public string Link { get; set; }
        public string CategoryName { get; set; }
        public string From { get; set; }
    }
}

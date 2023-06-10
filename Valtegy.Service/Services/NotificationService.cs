using Valtegy.Service.Options;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Valtegy.Domain.Models;
using Valtegy.Domain.Repositories;
using Valtegy.Domain.Services;
using Valtegy.Domain.ViewModels;
using Valtegy.Domain.Constants;

namespace Valtegy.Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IDataRepository<Domain.Entities.Notification> _notificationRepository;
        private readonly IEmailService _emailService;

        public NotificationService(IDataRepository<Domain.Entities.Notification> notificationRepository,
                                    IEmailService emailService,
                                    IConfiguration configuration,
                                    IOptions<FtpConfigurations> ftpOptions)
        {
            _notificationRepository = notificationRepository;
            _emailService = emailService;
        }

        public async Task<ResponseModel> CreateNotification(Guid? userId, CreateNotificationViewModel notification)
        {
            ResponseModel notificationResponse = new (false, "NotificationType not found.");
            int notificationStatus;
            string notificationError = string.Empty;

            if (notification.Type == NotificationType.Email)
            {
                notificationResponse = _emailService.Send(
                    notification.To,
                    notification.Subject,
                    notification.BobyMessage,
                    notification.IsBodyHtml,
                    notification.Cc,
                    notification.Cco);
            }          

            if (notificationResponse.Success)
            {
                notificationStatus = NotificationStatus.Sent;
            }
            else
            {
                notificationStatus = NotificationStatus.Failed;
                notificationError = notificationResponse.Message;
            }

            var entity = new Domain.Entities.Notification
            {
                Id = Guid.NewGuid(),
                To = notification.To,
                Cc = notification.Cc,
                Cco = notification.Cco,
                Subject = notification.Subject,
                BobyMessage = notification.BobyMessage,
                Type = notification.Type,
                IsBodyHtml = notification.IsBodyHtml,
                Status = notificationStatus,
                Error = notificationError,
                IsReaded = false,
                Link = notification.Link,
                CategoryName = notification.CategoryName,
                UserIdCreated = (Guid)userId,
                DateCreated = DateTimeOffset.Now,
                From = notification.From
            };

            var result = await _notificationRepository.AddAsync(entity);

            return new ResponseModel(true, result.Id);
        }
    }
}

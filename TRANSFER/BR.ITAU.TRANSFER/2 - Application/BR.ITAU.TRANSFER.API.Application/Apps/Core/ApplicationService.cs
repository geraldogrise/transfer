using BR.ITAU.TRANSFER.API.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.ITAU.TRANSFER.API.Application.Apps.Core
{
    public class ApplicationService
    {
        protected readonly IMediator _mediator;
        protected readonly DomainNotificationHandler _notifications;

        public ApplicationService(IMediator mediator,
                                 INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected void RaiseInformation(string message)
        {
            _mediator.Publish(new DomainNotification(NotificationType.Information, string.Empty, message));
        }

        protected void RaiseError(string message)
        {
            _mediator.Publish(new DomainNotification(NotificationType.Error, string.Empty, message));
        }

        protected bool Commit()
        {
            _mediator.Publish(new DomainNotification(NotificationType.Error, GetType().Name, "Erro ao persistir dados."));
            return false;
        }
    }
}

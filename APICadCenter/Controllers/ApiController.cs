using APICadCenter.ViewModels;
using Domain.Core.Bus;
using Domain.Core.Events;
using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected BaseController(INotificationHandler<DomainNotification> notifications,
                                IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotifications();
        }

        protected bool ModelStateValid()
        {
            if (ModelState.IsValid) return true;
            NotifyErrors();
            return false;
        }

        protected IEnumerable<string> GetNotifications()
        {
            return _notifications.GetNotifications().Select(n => n.Value);
        }

        protected void NotifyErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                _mediator.RaiseEvent(new DomainNotification(string.Empty, erroMsg)); 
            }
        }
         
        protected IActionResult ResponseAction(object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            if (Erro400())
            {

                return BadRequest(new ResponseViewModel
                {
                    Success = false,
                    Errors = _notifications.GetNotifications().Select(n => n.Value)
                });
            }
            else
            {
                return UnprocessableEntity(new ResponseViewModel
                {
                    Success = false,
                    Errors = _notifications.GetNotifications().Select(n => n.Value)
                });
            }
        }
        protected bool Erro400()
        {
            return _notifications.GetNotifications().Select(n => n.Key).Any(f => f.Equals("UserError"));
        }
    }
}

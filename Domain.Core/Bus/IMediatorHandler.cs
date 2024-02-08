using Domain.Core.Commands;
using Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task<U> SendCommand<T, U>(T command) where T : IRequest<U>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}

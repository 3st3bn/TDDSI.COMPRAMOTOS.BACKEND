using MediatR;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
public interface INotifyHandler<TCommand> : INotificationHandler<TCommand>
where TCommand : INotify {

}

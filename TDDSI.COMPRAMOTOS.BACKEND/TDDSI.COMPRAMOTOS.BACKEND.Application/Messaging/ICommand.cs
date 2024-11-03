using MediatR;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
public interface ICommand : IRequest<Result>, IBaseCommand {

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand {

}
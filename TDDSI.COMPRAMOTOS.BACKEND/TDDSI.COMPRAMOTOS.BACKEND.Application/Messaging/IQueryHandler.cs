using MediatR;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
public interface IQueryHandler<TQuery, TResponse>
: IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse> {

}

using MediatR;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>> {

}
using TDDSI.COMPRAMOTOS.BACKEND.Domain.DomainService;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Ports;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Users;
[DomainService]
public class UserService(
    IUnitOfWork unitOfWork
) {

    public async Task<Guid> CreateUserAsync(
        User user,
        CancellationToken cancellationToken
    ) {
        ArgumentNullException.ThrowIfNull( nameof( user ) );

        await unitOfWork.Repository<User>()
            .AddAsync( user, cancellationToken );

        return user.Id;
    }
}

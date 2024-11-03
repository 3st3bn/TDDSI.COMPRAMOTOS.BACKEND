﻿using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Users;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.Users.CreateUser;
internal sealed class UserCommandHandler(
    UserService userService
) : ICommandHandler<UserCommand, UserCommandResponse> {

    public async Task<Result<UserCommandResponse>> Handle( UserCommand request
        , CancellationToken cancellationToken
    ) {
        Guid id = await userService
            .CreateUserAsync(
                User.Create(
                    request.FirstName
                    , request.SecondName
                    , request.SurName
                    , request.SecondSurName
                )
                , cancellationToken
            );

        return new UserCommandResponse( id );
    }
}

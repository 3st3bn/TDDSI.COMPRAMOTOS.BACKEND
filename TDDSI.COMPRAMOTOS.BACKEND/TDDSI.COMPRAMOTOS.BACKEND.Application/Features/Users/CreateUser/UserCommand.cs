using System.ComponentModel.DataAnnotations;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.Users.CreateUser;
public record UserCommand(
    [Required] string FirstName
    , string? SecondName
    , [Required] string SurName
    , string? SecondSurName
    ) : ICommand<UserCommandResponse>;

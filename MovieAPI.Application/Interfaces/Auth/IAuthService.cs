using MovieAPI.Domain.Entities;
using System.Security.Claims;

namespace MovieAPI.Application.Interfaces;

public interface IAuthService
{
    string Token(User user);
    Claim[] GetClaims(User user);
}

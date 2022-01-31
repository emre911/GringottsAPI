using Gringotts.Data.Entities;
using GringottsAPI.Models;

namespace GringottsAPI.Business
{
    public interface IJwtAuthenticationManager
    {
        Token CreateToken(User appUser);
    }
}

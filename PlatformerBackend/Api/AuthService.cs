using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using mROA.Implementation.Attributes;
using PlatformerBackend.Models;

namespace PlatformerBackend.Api
{
    [SharedObjectSingleton]
    public class AuthService : IAuth
    {
        // public static PlatformerContext Context;

        public Task<LoginResponse> Login(string login, string password)
        {
            if (PlatformerContext.Instance.Players.FirstOrDefault(i => i.Login == login && i.Password == password) is { } user)
            {
                return Task.FromResult(new LoginResponse
                    { Handle = new PlayerHandle(user.Id, PlatformerContext.Instance), Name = user.Name });
            }

            throw new InvalidCredentialException();
        }
    }
}
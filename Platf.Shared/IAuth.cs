using System.Threading.Tasks;
using mROA.Implementation;
using mROA.Implementation.Attributes;

namespace PlatformerBackend.Api
{
    [SharedObjectInterface]
    public interface IAuth : IShared
    {
        Task<LoginResponse> Login(string login, string password);
    }
}
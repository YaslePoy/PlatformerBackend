using System.Threading.Tasks;
using mROA.Implementation;
using mROA.Implementation.Attributes;

namespace PlatformerBackend.Api
{
    [SharedObjectInterface]
    public interface IChatHub : IShared
    {
        Task<IChat> GetChat(string id);
        Task<string> Raiting();
    }
}
using System.Threading;
using System.Threading.Tasks;
using mROA.Implementation;
using mROA.Implementation.Attributes;

namespace PlatformerBackend.Api
{
    [SharedObjectInterface]
    public interface IPlayerHandle : IShared
    {
        Task SetScore(int value, CancellationToken token = default);
        Task SetStars(int value, CancellationToken token = default);
    }
}
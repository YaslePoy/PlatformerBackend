using System;
using System.Threading.Tasks;
using mROA.Implementation;
using mROA.Implementation.Attributes;

namespace PlatformerBackend.Api
{
    [SharedObjectInterface]
    public partial interface IChat : IShared
    {
        Task Post(IPlayerHandle user, string message);
        event Action<string, string> OnMessage;
    }
}
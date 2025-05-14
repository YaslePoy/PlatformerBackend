using System.Collections.Generic;
using System.Threading.Tasks;
using mROA.Implementation.Attributes;

namespace PlatformerBackend.Api
{
    [SharedObjectSingleton]
    public class ChatHub : IChatHub
    {
        private static Dictionary<string, IChat> _chats = new();
        public Task<IChat> GetChat(string id)
        {
            if  (!_chats.ContainsKey(id))
            {
                _chats[id] = new Chat();
            }
            
            return Task.FromResult(_chats[id]);

        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mROA.Implementation.Attributes;
using PlatformerBackend.Models;

namespace PlatformerBackend.Api
{
    [SharedObjectSingleton]
    public class ChatHub : IChatHub
    {
        private static Dictionary<string, IChat> _chats = new();

        public Task<IChat> GetChat(string id)
        {
            if (!_chats.ContainsKey(id))
            {
                _chats[id] = new Chat();
            }

            return Task.FromResult(_chats[id]);
        }

        public Task<string> Raiting()
        {
            var rank = 1;
            return Task.FromResult(string.Join("\r\n",
                PlatformerContext.Instance.Players.OrderByDescending(i => i.Score).ToList()
                    .Select(i => $"{rank++}. {i.Name}: {i.Score}")));
        }
    }
}
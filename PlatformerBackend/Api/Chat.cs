using System;
using System.Linq;
using System.Threading.Tasks;
using PlatformerBackend.Models;

namespace PlatformerBackend.Api
{
    public class Chat : IChat
    {
        public async Task Post(IPlayerHandle user, string message)
        {
            var sender = PlatformerContext.Instance.Players.FirstOrDefault(i => i.Id == (user as PlayerHandle).Id).Name;
            OnMessage(sender, message);
        }

        public event Action<string, string>? OnMessage;
        public void OnMessageExternal(string p0, string p1)
        {
            OnMessage(p0, p1);
        }
    }
}
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlatformerBackend.Models;

namespace PlatformerBackend.Api
{
    public class PlayerHandle : IPlayerHandle
    {
        public readonly int Id;
        private readonly PlatformerContext _context;

        public PlayerHandle(int id, PlatformerContext context)
        {
            Id = id;
            _context = context;
        }

        public async Task SetScore(int value, CancellationToken token = default)
        {
            var user = _context.Players.FirstOrDefault(i => i.Id == Id);
            user.Score = value;
            _context.Players.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SetStars(int value, CancellationToken token = default)
        {
            var user = _context.Players.FirstOrDefault(i => i.Id == Id);
            user.Stars = value;
            _context.Players.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
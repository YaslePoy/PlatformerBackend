namespace PlatformerBackend.Api
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int[] Levels { get; set; }
        public IPlayerHandle Handle { get; set; }
    }
}
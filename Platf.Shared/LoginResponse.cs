namespace PlatformerBackend.Api
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public IPlayerHandle Handle { get; set; }
    }
}
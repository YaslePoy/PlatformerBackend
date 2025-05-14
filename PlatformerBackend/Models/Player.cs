namespace PlatformerBackend.Models
{
    public class Player : DbEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Stars { get; set;}
        public int Score { get; set; }
    }
}
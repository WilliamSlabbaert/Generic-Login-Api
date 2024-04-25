namespace DataLayer.Entities
{
    public class App
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public User User { get; set; }
        public bool HasAccess { get; set; }
    }
}

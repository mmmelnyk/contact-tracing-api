namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string DeviceId { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
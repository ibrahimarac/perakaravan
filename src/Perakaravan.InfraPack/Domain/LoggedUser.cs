namespace Perakaravan.InfraPack.Domain
{
    public class LoggedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public string Fullname { get { return $"{Name} {Surname}"; } }
    }
}

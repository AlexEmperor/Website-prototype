namespace WEBtest.Db.Models
{
    public class Favourite
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Items { get; set; }
    }
}

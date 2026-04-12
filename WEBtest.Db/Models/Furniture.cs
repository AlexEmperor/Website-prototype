namespace WEBtest.Db.Models
{
    public class Furniture
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string OrderPlace { get; set; }

        ////////////////////////////////////////////////////////////////////
        public int HardNumber { get; set; }

    }
}

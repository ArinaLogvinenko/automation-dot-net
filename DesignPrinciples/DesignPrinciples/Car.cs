namespace DesignPrinciples
{
    public class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public Car (string brand, string model, decimal price, int count)
        {
            this.Brand = brand;
            this.Model = model;
            this.Price = price;
            this.Count = count;
        }
    }
}

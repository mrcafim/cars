
namespace Cars.Domain.Entities
{
    public class Car : Entity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public string Plate { get; set; }
        public DateTime MakeDate { get; set; }

        public Car()
        { }

        public Car(string make, string model, string color, string plate, DateTime makeDate)
        {
            Make = make;
            Model = model;
            Color = color;
            Plate = plate;
            MakeDate = makeDate;
        }
    }
}

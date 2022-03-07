namespace Cars.Domain.Entities
{
    public class Model : Entity
    {
        public string Name { get; set; }
        public Guid MakeId { get; set; }

        public Model()
        { }

        public Model(string name, Guid makeId)
        {
            Name = name;
            MakeId = makeId;
        }
    }
}

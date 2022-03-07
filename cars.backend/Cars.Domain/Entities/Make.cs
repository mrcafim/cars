namespace Cars.Domain.Entities
{
    public class Make : Entity
    {
        public string Name { get; set; }
        public List<Model> Models { get; set; }

        public Make()
        { }

        public Make(string name, List<Model> models)
        {
            Name = name;
            Models = models;
        }
    }
}

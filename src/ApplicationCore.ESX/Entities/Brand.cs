namespace ApplicationCore.ESX.Entities
{
    public class Brand : EntityBase
    {
        public Brand() { } //by ef

        public Brand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}

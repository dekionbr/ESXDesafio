namespace ApplicationCore.ESX.Entities
{
    /// <summary>
    ///  Regras:
    ///  A Propriedade NumberAssets deve ser auto-incremento.
    /// </summary>
    public class Assets : EntityBase
    {
        public Assets() { } //by ef

        public Assets(int brandId, string name, string description)
        {
            BrandId = brandId;
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public int NumberAssets { get; set; }
    }
}

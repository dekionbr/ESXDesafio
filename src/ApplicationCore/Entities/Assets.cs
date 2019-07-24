namespace ApplicationCore.Entities
{
    /// <summary>
    ///  Regras:
    ///  A Propriedade NumberAssets deve ser auto-incremento.
    /// </summary>
    public class Assets : EntityBase
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public int NumberAssets { get; set; }
    }
}

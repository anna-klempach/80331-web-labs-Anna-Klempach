namespace WebLabs_Klempach.DAL.Entities
{
    public class Loot
    {
        public int LootId { get; set; }
        public string LootName { get; set; }
        public string LootDescription { get; set; }
        public double LootPrice { get; set; }
        public string LootImageName { get; set; }
        public string LootImageMimeType { get; set; }

        public LootCategory Category { get; set; }
        public int LootCategoryId { get; set; }
    }
}

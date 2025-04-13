namespace EndangerPlantApp.Data.Entities
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }

        // public string(?) Location {get;set;} <- i have no clue what kind of variable a LOCATION is
    }
}

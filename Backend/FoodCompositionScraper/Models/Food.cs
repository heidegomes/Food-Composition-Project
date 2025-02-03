namespace FoodCompositionScraper.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Group { get; set; }
        public string Component { get; set; }
        public string Unit { get; set; }
        public string ValuePer100g { get; set; }
        public string StandardDeviation { get; set; }
        public string MinimumValue { get; set; }
        public string MaximumValue { get; set; }
        public string NumberSamples { get; set; }
        public string Reference { get; set; }
        public string DataType { get; set; }
        // Outras propriedades de acordo com os dados que você está extraindo
    }
}

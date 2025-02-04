using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodCompositionScraper.Models
{
    public class FoodData
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Group { get; set; }

        public List<FoodDataComponent>? Components { get; set; }
    }

    public class FoodDataComponent
    {
        [Key]
        public int Id { get; set; }

        // Chave estrangeira referenciando a tabela Food
        public string FoodCode { get; set; }
        [ForeignKey("FoodCode")]
        [JsonIgnore]
        public FoodData FoodData { get; set; }

        public string Component { get; set; }
        public string Unit { get; set; }
        public string ValuePer100g { get; set; }
        public string StandardDeviation { get; set; }
        public string MinimumValue { get; set; }
        public string MaximumValue { get; set; }
        public string NumberSamples { get; set; }
        public string Reference { get; set; }
        public string DataType { get; set; }
    }
}

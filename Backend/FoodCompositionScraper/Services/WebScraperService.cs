using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodCompositionScraper.Models;

namespace FoodCompositionScraper.Services
{
    public class WebScraperService
    {
        private readonly string _url = "https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";
        private readonly FoodService _foodService;

        public WebScraperService(FoodService foodService)
        {
            _foodService = foodService;
        }

        public async Task<List<FoodData>> ScrapeFoodDataAsync()
        {
            var foodList = new List<FoodData>();
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(_url);

            var rows = doc.DocumentNode.SelectNodes("//table//tr");

            // Adicionar checagem de null para rows
            if (rows == null)
            {
                throw new Exception("Não foi possível encontrar as linhas da tabela.");
            }

            foreach (var row in rows)
            {
                // Leitura das colunas da tabela
                var columns = row.SelectNodes("td");
                if (columns != null && columns.Count >= 4)
                {
                    foodList.Add(new FoodData
                    {
                        Code = columns[0].InnerText.Trim(),
                        Name = columns[1].InnerText.Trim(),
                        ScientificName = columns[2].InnerText.Trim(),
                        Group = columns[3].InnerText.Trim(),
                        Components = null
                    });
                }
            }

            // leitura de cada item associado ao código
            var webByCode = new HtmlWeb();            
            foreach (var food in foodList) 
            {
                Console.WriteLine($"Extraindo dados do code: {food.Code}");
                var urlCode = food.Code;
                var _urlByCode = $"https://www.tbca.net.br/base-dados/int_composicao_estatistica.php?cod_produto={urlCode}";

                var docByCode = await webByCode.LoadFromWebAsync(_urlByCode);

                var rowsByCode = docByCode.DocumentNode.SelectNodes("//table//tr");

                // Adicionar checagem de null para rows
                if (rowsByCode == null)  
                {
                    throw new Exception($"Não foi possível encontrar as linhas da tabela do código {urlCode}.");
                }

                var componentsList = new List<FoodDataComponent>();

                foreach (var row2 in rowsByCode)
                {
                    // Leitura das colunas da tabela
                    var columns = row2.SelectNodes("td");

                    if (columns != null && columns.Count >= 9)
                    {
                        var component = new FoodDataComponent
                        {
                            FoodCode = food.Code,
                            Unit = columns[1].InnerText.Trim(),
                            ValuePer100g = columns[2].InnerText.Trim(),
                            StandardDeviation = columns[3].InnerText.Trim(),
                            MinimumValue = columns[4].InnerText.Trim(),
                            MaximumValue = columns[5].InnerText.Trim(),
                            NumberSamples = columns[6].InnerText.Trim(),
                            Reference = columns[7].InnerText.Trim(),
                            DataType = columns[8].InnerText.Trim(),
                            Component = !string.IsNullOrWhiteSpace(columns[0].InnerText.Trim()) ? columns[0].InnerText.Trim() : ""
                        };
                        componentsList.Add(component);
                    }      
                }

                if (componentsList.Any())
                {
                    food.Components = componentsList;
                }                
            }

            await _foodService.AddFoodsAsync(foodList);

            return foodList;
        }
    }
}

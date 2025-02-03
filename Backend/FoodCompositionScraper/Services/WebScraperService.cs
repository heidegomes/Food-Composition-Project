using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCompositionScraper.Services
{
    public class FoodData
    {
        public string Code { get; set; }
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
    }

    public class WebScraperService
    {
        private readonly string _url = "https://www.tbca.net.br/base-dados/composicao_estatistica.php?pagina=1&atuald=1#";
        
        // Definir foodList como variável de instância
        private List<FoodData> foodList = new List<FoodData>();

        public async Task<List<FoodData>> ScrapeFoodDataAsync()
        {
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
                        Group = columns[3].InnerText.Trim()
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

                foreach (var row2 in rowsByCode)
                {
                    // Leitura das colunas da tabela
                    var columns = row2.SelectNodes("td");

                    if (columns != null && columns.Count >= 9)
                    {
                        food.Component = columns[0].InnerText.Trim();
                        food.Unit = columns[1].InnerText.Trim();
                        food.ValuePer100g = columns[2].InnerText.Trim();
                        food.StandardDeviation = columns[3].InnerText.Trim();
                        food.MinimumValue = columns[4].InnerText.Trim();
                        food.MaximumValue = columns[5].InnerText.Trim();
                        food.NumberSamples = columns[6].InnerText.Trim();
                        food.Reference = columns[7].InnerText.Trim();
                        food.DataType = columns[8].InnerText.Trim();                
                    }      
                }
            } 
            return foodList;
        }
        // Método para retornar todos os alimentos
        public Task<List<FoodData>> GetFoodsAsync()
        {
            return Task.FromResult(foodList); // Retorna os alimentos já extraídos
        }

        // Método para retornar um alimento específico pelo código
        public Task<FoodData> GetFoodByIdAsync(string code)
        {
            var food = foodList.FirstOrDefault(f => f.Code == code); // Procura pelo código
            return Task.FromResult(food);
        }
    }
}

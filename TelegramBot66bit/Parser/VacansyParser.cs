using System.Net;

namespace TelegramBot66bit.Parser
{
    public record VacancyDto(string Title, int Count, string TaskUrl);

    public class VacancyParser
    {
        private readonly HttpClient _httpClient = new();

        public async Task<List<VacancyDto>> GetVacancyListAsync()
        {
            var url = "https://practice.66bit.ru";
            var html = await _httpClient.GetStringAsync(url);

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var vacancyItems = doc.DocumentNode.SelectNodes("//div[contains(@class, 'direction-list__item')]");
            var result = new List<VacancyDto>();

            if (vacancyItems != null)
            {
                foreach (var item in vacancyItems)
                {
                    var h3Node = item.SelectSingleNode(".//h3[contains(@class, 'direction-item__title')]");
                    var strikeNode = h3Node?.SelectSingleNode(".//s");

                    string rawTitle = strikeNode?.InnerText ?? h3Node?.InnerText ?? "Без названия";
                    string title = WebUtility.HtmlDecode(rawTitle.Trim());

                    var countNode = item.SelectSingleNode(".//div[contains(@class, 'direction-item__count')]//span");
                    string countText = WebUtility.HtmlDecode(countNode?.InnerText.Trim() ?? "0");
                    int.TryParse(countText, out int count);

                    var taskNode = item.SelectSingleNode(".//div[contains(@class, 'direction-item__job')]//a");
                    string taskUrl = taskNode?.GetAttributeValue("href", "") ?? "";

                    result.Add(new VacancyDto(title, count, taskUrl));
                }
            }

            return result;
        }
    }
}
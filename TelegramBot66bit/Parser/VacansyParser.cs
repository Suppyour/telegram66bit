using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace TelegramBot66bit.Parser
{
    public class VacancyParser
    {
        private readonly HttpClient _httpClient = new();

        public async Task<string> GetVacancyInfoAsync()
        {
            var url = "https://practice.66bit.ru";
            var html = await _httpClient.GetStringAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var vacancyItems = doc.DocumentNode.SelectNodes("//div[contains(@class, 'direction-list__item')]");
            var sb = new StringBuilder();

            if (vacancyItems != null)
            {
                foreach (var item in vacancyItems)
                {
                    var h3Node = item.SelectSingleNode(".//h3[contains(@class, 'direction-item__title')]");
                    var strikeNode = h3Node?.SelectSingleNode(".//s");

                    string rawTitle = strikeNode?.InnerText ?? h3Node?.InnerText ?? "Без названия";
                    string title = WebUtility.HtmlDecode(rawTitle.Trim());

                    var countNode = item.SelectSingleNode(".//div[contains(@class, 'direction-item__count')]//span");
                    string count = WebUtility.HtmlDecode(countNode?.InnerText.Trim() ?? "—");

                    if (title != "Без названия" && count != "—")
                    {
                        sb.AppendLine($"{title} — Количество мест: {count}");
                    }
                }
            }
            else
            {
                sb.AppendLine("Не удалось найти вакансии. Возможно, структура сайта изменилась.");
            }

            return sb.ToString();
        }
    }
}
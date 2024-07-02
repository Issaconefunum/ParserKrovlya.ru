using System.Text.RegularExpressions;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using APIParser.Models;
using AngleSharp.Dom;

namespace APIParser.Services.ParserService.Core.Krovlya
{
    internal class KrovlyaParser : IParser
    {
        public List<KrovlyaCard> Parse(IHtmlDocument document)
        {
            var ticket = document.QuerySelectorAll("div.element.elem-hover-height-more");
            if (ticket == null || ticket.Length == 0) throw new InvalidOperationException("Data not found");
            var KrovlyaCardList = new List<KrovlyaCard>();
            foreach (var tick in ticket)
            {
                var KrovlyaCard = new KrovlyaCard();
                KrovlyaCard.Name = DeleateExtraCharacters(tick.QuerySelector("div.name").TextContent ?? "Not Found Data");
                KrovlyaCard.Cost = DeleateExtraCharacters(tick.QuerySelector("div.price-cell.price").TextContent ?? "Not Found Data");          
                KrovlyaCardList.Add(KrovlyaCard);
            }
            return KrovlyaCardList;
        }
        public string DeleateExtraCharacters(string request)
        {
            if (request == null) throw new InvalidOperationException("Data not found");

            string pattern = @"\s+";
            string replacement = " ";

            return Regex.Replace(request, pattern, replacement).Trim();
        }
    }
}

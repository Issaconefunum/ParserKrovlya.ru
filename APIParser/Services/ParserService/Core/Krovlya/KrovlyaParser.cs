using System.Text.RegularExpressions;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APIParser.Services.ParserService.Core.Krovlya
{
    internal class KrovlyaParser : IParser<KrovlyaCard[]>
    {
        public KrovlyaCard[] Parse(IHtmlDocument document)
        {
            var ticket = document.QuerySelectorAll("div.element.elem-hover-height-more");
            var KrovlyaCardList = new List<KrovlyaCard>();
            foreach (var tick in ticket)
            {
                string pattern = @"\s+";
                string replacement = " ";

                var KrovlyaCard = new KrovlyaCard();
                KrovlyaCard.Name = Regex.Replace(tick.QuerySelector("div.name").TextContent, pattern, replacement);
                KrovlyaCard.Cost = Regex.Replace(tick.QuerySelector("div.price-cell.price").TextContent, pattern, replacement);
                var image = tick.QuerySelector("img.img-responsive.center-block.animate_to_box.lazyload");
                KrovlyaCard.Image = image.GetAttribute("data-src");

                KrovlyaCardList.Add(KrovlyaCard);
            }







            return KrovlyaCardList.ToArray();
        }
    }
}

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
    internal class KrovlyaParser : IParser<KrovlyaCard[]>
    {
        public KrovlyaCard[] Parse(IHtmlDocument document)
        {
            var ticket = document.QuerySelectorAll("div.element.elem-hover-height-more");
            if (ticket == null) throw new InvalidOperationException("Data not found");
            var KrovlyaCardList = new List<KrovlyaCard>();
            foreach (var tick in ticket)
            {

                var KrovlyaCard = new KrovlyaCard();
                KrovlyaCard.Name = check(tick.QuerySelector("div.name").TextContent);
                KrovlyaCard.Cost = check(tick.QuerySelector("div.price-cell.price").TextContent);
                //var image = tick.QuerySelector("img.img-responsive.center-block.animate_to_box.lazyload");
                //KrovlyaCard.Image = image.GetAttribute("data-src");
                KrovlyaCardList.Add(KrovlyaCard);
            }
            






            return KrovlyaCardList.ToArray();
        }
        public string check(string request)
        {
            if (request == null) throw new InvalidOperationException("Data not found");

            string pattern = @"\s+";
            string replacement = " ";

            return Regex.Replace(request, pattern, replacement); ;
        }
    }
}

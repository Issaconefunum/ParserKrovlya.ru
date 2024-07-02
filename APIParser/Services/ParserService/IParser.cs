using AngleSharp.Html.Dom;
using APIParser.Models;

namespace APIParser.Services.ParserService
{
    internal interface IParser
    {
        List<KrovlyaCard> Parse(IHtmlDocument document);
    }
}

using AngleSharp.Html.Dom;

namespace APIParser.Services.ParserService
{
    internal interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}

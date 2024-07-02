using AngleSharp.Html.Parser;
using APIParser.Models;
using APIParser.ConfigurationManager;
using AngleSharp;

namespace APIParser.Services.ParserService
{
    class ParserWorker<T> where T : class
    {
        IParser parser;

        #region Properties 
        public IParser Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        #endregion  

        public ParserWorker(IParser parser)
        {
            this.parser = parser;
        }
        /*public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }*/
        public async Task<List<KrovlyaCard>> GetProductsParse()
        {
            var list = new List<KrovlyaCard>();
            for (int i = Configurations.ParserSettings.StartPoint; i <= Configurations.ParserSettings.EndPoint; i++)
            {
                var source = await HtmlLoader.GetSourceByPageId(Configurations.ParserSettings.Url, i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
                list.AddRange(result);

            }
            return list;

        }
    }
}

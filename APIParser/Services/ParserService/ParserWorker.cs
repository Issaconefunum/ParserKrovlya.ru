using AngleSharp.Html.Parser;

namespace APIParser.Services.ParserService
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;

        #region Properties 
        public IParser<T> Parser
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
        public IParserSettings Settings
        {
            get { return parserSettings; }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        #endregion  

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }
        /*public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }*/
        private async void Start_Worker()
        {
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                var source = await loader.GetSourceByPageId(parserSettings.BaseUrl, i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
            }
        }
    }
}

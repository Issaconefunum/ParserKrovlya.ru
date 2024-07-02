using APIParser.ConfigurationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIParser.Services.ParserService.Core.Krovlya
{
    internal class KrovlyaSettings : IParserSettings
    {
        public KrovlyaSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://krovlya.itm.su/?utm_source=yandex&utm_medium=novator&utm_campaign=poisk&utm_content=10453459512&utm_term=%D0%B8%D0%B6%D1%82%D0%BE%D1%80%D0%B3%D0%BC%D0%B5%D1%82%D0%B0%D0%BB%D0%BB&calltouch_tm=yd_c:59842495_gb:4501514036_ad:10453459512_ph:39283255974_st:search_pt:premium_p:1_s:none_dt:desktop_reg:44_ret:39283255974_apt:none&yclid=13453932275635585023";
        public string Prefix { get; set; } = "{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}

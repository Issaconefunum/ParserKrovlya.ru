using APIParser.Models;
using APIParser.Services.ParserService.Core.Krovlya;
using APIParser.Services.ParserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace APIParser.Controllers
{
    [Route("/HomeController/[action]")]
    public class HomeController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ParserResult()
        {
            ParserWorker<KrovlyaCard[]> parser = new ParserWorker<KrovlyaCard[]>(new KrovlyaParser());
            var content = await parser.GetProductsParse();
            return Ok(content);
        }
        [HttpGet]
        public async Task SearchData()
        {
            string content = @"<form method='post'>
                <label>Name:</label><br />
                <input name='name' /><br />
               <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);
        }
        [HttpPost]
        public async Task<IActionResult> SearchData(string name)
        {
            var list = new List<KrovlyaCard>();
            ParserWorker<KrovlyaCard[]> parser = new ParserWorker<KrovlyaCard[]>(new KrovlyaParser());
            var content = await parser.GetProductsParse();
            foreach (var card in content) 
            {
                if (card.Name.Contains(name))
                {
                    list.Add(card);
                }
            }

            return Ok(list);
        }
    }
}

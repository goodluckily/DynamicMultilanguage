using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DynamicMultilanguage.Localize;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace DynamicMultilanguage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IStringLocalizer<Resource> _localizer;

        public HomeController(IStringLocalizer<Resource> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public object Get()
        {
            var culturesValue = _localizer["Home"];
            var culturesValueParams = _localizer["HomeTitie", "雨太阳", "66666"];

            return new { culturesValue, culturesValueParams };
        }

        /// <summary>
        /// 参考多语言文化的类型All
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCultures")]
        public object GetAllCultures()
        {
            var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var dicAllCultures = new Dictionary<string, string>();
            foreach (var ci in allCultures)
            {
                // 显示每个文化的名称。
                dicAllCultures.Add(ci.EnglishName, ci.Name);
                Console.Write($"{ci.EnglishName} ({ci.Name}): ");
                // 显示的文化类型。
                if (ci.CultureTypes.HasFlag(CultureTypes.NeutralCultures))
                    Console.Write(" NeutralCulture");
                if (ci.CultureTypes.HasFlag(CultureTypes.SpecificCultures))
                    Console.Write(" SpecificCulture");
                Console.WriteLine();
            }
            return dicAllCultures;
        }
    }
}

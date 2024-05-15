using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Primitives;

namespace DynamicMultilanguage.Extensions
{
    public class CultureRequestCultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException();
            }

            #region 方式一从Cookies里面按需获取语言 注释
            //var CULTURE_String = "CULTURE";
            //var CultureValue = httpContext.Request.Cookies[CULTURE_String]?.ToString() ?? "";
            //if (string.IsNullOrWhiteSpace(CultureValue))
            //{
            //    CultureValue = "zh-Hans";
            //    httpContext.Response.Cookies.Append(key: CULTURE_String, value: CultureValue, options: new CookieOptions() { Expires = DateTime.Now.AddYears(1) });
            //} 
            #endregion

            //方式二 从Headers里面按需获取语言
            var culture = new StringSegment("zh-Hans");
            var uiCulture = new StringSegment("zh-Hans");
            var lang = httpContext.Request.Headers["Accept-Language"].ToString() ?? "";
            switch (lang)
            {
                case "en-US":
                    //英文
                    culture = new StringSegment("en-US");
                    uiCulture = new StringSegment("en-US");
                    break;
                case "zh-Hans":
                    //简体中文
                    culture = new StringSegment("zh-Hans");
                    uiCulture = new StringSegment("zh-Hans");
                    break;
                case "zh-Hant":
                    //繁体中文-台湾
                    culture = new StringSegment("zh-Hant");
                    uiCulture = new StringSegment("zh-Hant");
                    break;
                default:
                    goto case "zh-Hans";
            }
            return Task.FromResult(new ProviderCultureResult(culture, uiCulture));
        }
    }
}

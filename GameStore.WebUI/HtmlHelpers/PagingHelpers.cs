using System;
using System.Text;
using System.Web.Mvc;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        /// <summary>
        /// Данный расширяющий метод генерирует HTML-разметку для набора ссылок на
        /// страницы с использованием информации, в объекте PagingInfo
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pagingInfo"></param>
        /// <param name="pageUrl">делегат, который применяется для генерации ссылок, обеспечивающих просмотр других страниц.</param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                              PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
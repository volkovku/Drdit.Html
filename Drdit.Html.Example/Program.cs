using System;
using System.Linq;
using static Drdit.Html.HtmlTags;
using a = Drdit.Html.HtmlAttributes;

namespace Drdit.Html.Example
{
    static class Program
    {
        public static void Main()
        {
            var chars = new[] {"A", "B", "C", "D"};
            var page =
                html[
                    head[
                        meta[a.charset > "utf-8"],
                        title["Hello world"]
                    ],
                    body[
                        div[
                            p[a.style > "font-weight: bold"]["List of chars:"],
                            ul[chars.Select(_ => li[_])],
                            p["Some text ", b["and another text"], p]
                        ]
                    ]
                ];

            Console.WriteLine(page.Render());
        }
    }
}
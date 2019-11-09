# Drdit.Html Project

Drdit.Html is a simple and lightweight, DSL-based, HTML construction library for C#.


# Example

This C# code:

```csharp
// using static Drdit.Html.HtmlTags;
// using a = Drdit.Html.HtmlAttributes;
html[
    head[
        meta[a.charset > "utf-8"],
        title[a.style > "font-weight: bold"]["Hello world"]
    ],
    body[
        div[
            p["List of chars:"],
            ul[chars.Select(_ => li[_])],
            p["Some text ", b["and another text"], p]
        ]
    ]
];
```

turns into HTML like:

```html
<html>
    <head>
        <meta charset="utf-8" />
        <title style="font-weight: bold">Hello world</title>
    </head>
    <body>
        <div>
            <p>List of chars:</p>
            <ul>
                <li>A</li>
                <li>B</li>
                <li>C</li>
                <li>D</li>
            </ul>
            <p>
                Some text <b>and another text</b>
                <p />
            </p>
        </div>
    </body>
</html>
```

# Motivation

Writing HTML in pure C# code without large frameworks like RazorTemplates with alien syntactics elements and slow editor.
This HTML constructing library is closest to HTML as possible in C# language aspects.
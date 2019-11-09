using System;
using System.Collections.Generic;
using System.Linq;

namespace Drdit.Html
{
    public class HtmlElement : HtmlContent
    {
        public readonly string Tag;
        public readonly bool Inline;

        public HtmlElement(string tag, bool inline = false)
        {
            Tag = tag;
            Inline = inline;
        }

        public HtmlElementWithAttributes this[params HtmlAttribute[] attributes] =>
            new HtmlElementWithAttributes(Tag, Inline, attributes);

        public HtmlElementWithAttributesAndContent this[params HtmlContent[] content] =>
            new HtmlElementWithAttributesAndContent(Tag, Inline, Array.Empty<HtmlAttribute>(), content);

        public HtmlElementWithAttributesAndContent this[IEnumerable<HtmlContent> content] =>
            new HtmlElementWithAttributesAndContent(Tag, Inline, Array.Empty<HtmlAttribute>(),
                content.ToArray());

        public override void Render(IWriter writer) =>
            HtmlElementRenderer.RenderHtmlElement(
                writer,
                Tag,
                Array.Empty<HtmlAttribute>(),
                Array.Empty<HtmlContent>());
    }

    public class HtmlElementWithAttributes : HtmlContent
    {
        internal readonly string Tag;
        internal readonly bool Inline;
        internal readonly IReadOnlyList<HtmlAttribute> Attributes;

        internal HtmlElementWithAttributes(
            string tag,
            bool inline,
            IReadOnlyList<HtmlAttribute> attributes)
        {
            Tag = tag;
            Attributes = attributes;
            Inline = inline;
        }

        public HtmlElementWithAttributesAndContent this[params HtmlContent[] content] =>
            new HtmlElementWithAttributesAndContent(Tag, Inline, Attributes, content);

        public HtmlElementWithAttributesAndContent this[IEnumerable<HtmlContent> content] =>
            new HtmlElementWithAttributesAndContent(Tag, Inline, Attributes, content.ToArray());

        public override void Render(IWriter writer) =>
            HtmlElementRenderer.RenderHtmlElement(
                writer,
                Tag,
                Attributes,
                Array.Empty<HtmlContent>());
    }

    public class HtmlElementWithAttributesAndContent : HtmlContent
    {
        internal readonly string Tag;
        internal readonly bool Inline;
        internal readonly IReadOnlyList<HtmlAttribute> Attributes;
        internal readonly IReadOnlyList<HtmlContent> Content;

        internal HtmlElementWithAttributesAndContent(
            string tag,
            bool inline,
            IReadOnlyList<HtmlAttribute> attributes,
            IReadOnlyList<HtmlContent> content)
        {
            Tag = tag;
            Attributes = attributes;
            Content = content;
            Inline = inline;
        }

        public override void Render(IWriter writer) =>
            HtmlElementRenderer.RenderHtmlElement(
                writer,
                Tag,
                Attributes,
                Content);
    }
}
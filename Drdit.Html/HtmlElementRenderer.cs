using System.Collections.Generic;

namespace Drdit.Html
{
    internal static class HtmlElementRenderer
    {
        public static void RenderHtmlElement(
            IWriter writer,
            string tag,
            IReadOnlyList<HtmlAttribute> attributes,
            IReadOnlyList<HtmlContent> content)
        {
            writer.Write('<');
            writer.Write(tag);

            foreach (var attr in attributes)
            {
                writer.Write(' ');
                writer.WriteEncoded(attr.Name);

                if (!string.IsNullOrEmpty(attr.Value))
                {
                    writer.Write('=');
                    writer.Write('"');
                    writer.WriteEncoded(attr.Value);
                    writer.Write('"');
                }
            }

            if (content.Count == 0)
            {
                writer.Write(' ');
                writer.Write('/');
                writer.Write('>');
                return;
            }

            writer.Write(">");

            var indentRequired = IsIndentRequired(content);
            var continueInline = false;
            foreach (var contentUnit in content)
            {
                if (continueInline && IsIndentRequired(contentUnit))
                {
                    continueInline = false;
                    writer.IndentEnd();
                }

                if (indentRequired && !continueInline)
                {
                    writer.IndentStart();
                    writer.NewLine();
                }

                contentUnit.Render(writer);
                continueInline = !IsIndentRequired(contentUnit);

                if (indentRequired && !continueInline)
                {
                    writer.IndentEnd();
                }
            }

            if (indentRequired)
            {
                if (continueInline)
                {
                    writer.IndentEnd();
                }

                writer.NewLine();
            }

            writer.Write('<');
            writer.Write('/');
            writer.Write(tag);
            writer.Write(">");
        }

        private static bool IsIndentRequired(IEnumerable<HtmlContent> content)
        {
            foreach (var unit in content)
            {
                if (IsIndentRequired(unit))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsIndentRequired(HtmlContent content)
        {
            if (content is HtmlElement el && !el.Inline)
            {
                return true;
            }

            if (content is HtmlElementWithAttributes elWithAttr &&
                !elWithAttr.Inline)
            {
                return true;
            }

            if (content is HtmlElementWithAttributesAndContent elWithAttrAndContent &&
                (!elWithAttrAndContent.Inline || IsIndentRequired(elWithAttrAndContent.Content)))
            {
                return true;
            }

            return false;
        }
        
        
    }
}
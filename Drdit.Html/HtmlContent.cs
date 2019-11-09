namespace Drdit.Html
{
    public abstract class HtmlContent
    {
        public string Render()
        {
            var writer = new StringBuilderWriter();
            Render(writer);
            return writer.ToString();
        }

        public abstract void Render(IWriter writer);

        public static implicit operator HtmlContent(string content)
        {
            return new HtmlString(content);
        }

        public static HtmlContent[] operator +(string str, HtmlContent content)
        {
            return new[] {new HtmlString(str), content};
        }

        public static HtmlContent[] operator +(HtmlContent content, string str)
        {
            return new[] {content, new HtmlString(str)};
        }
    }
}
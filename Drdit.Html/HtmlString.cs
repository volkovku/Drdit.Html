namespace Drdit.Html
{
    public class HtmlString : HtmlContent
    {
        private readonly string _content;

        public HtmlString(string content)
        {
            _content = content;
        }
        
        public override void Render(IWriter writer)
        {
            if (string.IsNullOrWhiteSpace(_content))
            {
                return;
            }

            foreach (var ch in _content)
            {
                writer.WriteEncoded(ch);
            }
        }
    }
}
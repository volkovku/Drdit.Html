namespace Drdit.Html
{
    public class HtmlAttribute
    {
        public readonly string Name;
        public readonly string Value;

        public HtmlAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public static HtmlAttribute operator >(HtmlAttribute name, string value)
        {
            return new HtmlAttribute(name.Name, value);
        }

        public static HtmlAttribute operator <(HtmlAttribute name, string value)
        {
            return new HtmlAttribute(name.Name, value);
        }
    }
}
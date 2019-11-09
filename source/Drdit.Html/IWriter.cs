using System;

namespace Drdit.Html
{
    public interface IWriter
    {
        void NewLine();
        void IndentStart();
        void IndentEnd();
        void Write(char ch);
        void Write(string content);
    }

    public static class WriterCompanion
    {
        public static void WriteEncoded(this IWriter writer, string str)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            
            foreach (var ch in str)
            {
                if (ch == '\r')
                {
                    continue;
                }

                if (ch == '\n')
                {
                    writer.NewLine();
                    continue;
                }

                writer.WriteEncoded(ch);
            }
        }

        public static void WriteEncoded(this IWriter writer, char ch)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            switch (ch)
            {
                case '"':
                    writer.Write("&quot;");
                    return;
                case '<':
                    writer.Write("&lt;");
                    return;
                case '>':
                    writer.Write("&gt;");
                    return;
                case '&':
                    writer.Write("&amp;");
                    return;
                case '\'':
                    writer.Write("&#39;");
                    return;
                case '\r':
                    return;
                case '\n':
                    writer.Write(' ');
                    return;
                default:
                    writer.Write(ch);
                    return;
            }
        }
    }
}
using System;
using System.Text;

namespace Drdit.Html
{
    public class StringBuilderWriter : IWriter
    {
        private readonly StringBuilder _stringBuilder;
        private readonly int _indentSize;
        private int _indent;

        public StringBuilderWriter(StringBuilder stringBuilder = null, int indentSize = 4)
        {
            if (indentSize < 0)
            {
                throw new ArgumentException(
                    "Indent size should be a positive integer value, " +
                    $"but {indentSize} was found.");
            }

            _stringBuilder = stringBuilder ?? new StringBuilder();
            _indentSize = indentSize;
        }

        public void NewLine()
        {
            _stringBuilder.AppendLine();
            for (var i = 0; i < _indent; i++)
            {
                _stringBuilder.Append(' ');
            }
        }

        public void IndentStart()
        {
            _indent += _indentSize;
        }

        public void IndentEnd()
        {
            _indent -= _indentSize;
        }

        public void Write(char ch)
        {
            _stringBuilder.Append(ch);
        }

        public void Write(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            foreach (var ch in content)
            {
                if (ch == '\r')
                {
                    continue;
                }

                if (ch == '\n')
                {
                    NewLine();
                    continue;
                }

                _stringBuilder.Append(ch);
            }
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}
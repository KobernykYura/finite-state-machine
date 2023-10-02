using System.Text.RegularExpressions;
using FiniteStateMachine.FsmParser.Interfaces;

namespace FiniteStateMachine.FsmParser
{
    public class Lexer
    {
        private int currentPosition = 0;
        private int currentLine = 0;

        private Regex whitePattern = new Regex("^\\s+");
        private Regex namePattern = new Regex("^\\w+");

        private ITokenCollector collector;

        public Lexer(ITokenCollector collector)
        {
            this.collector = collector;
        }

        /// <summary>
        /// Does lexical analysis of the given string.
        /// </summary>
        /// <param name="s"></param>
        public void Lex(string stream)
        {
            this.currentLine = 0;
            IEnumerable<string> lines = stream.Split("\n");

            foreach (var line in lines)
            {
                this.currentLine++;
                this.LexLine(line);
            }
        }

        private void LexLine(string line)
        {
            for (this.currentPosition = 0; this.currentPosition < line.Length;)
                this.LexToken(line);
        }

        private void LexToken(string line)
        {
            if (!this.IsValidToken(line))
            {
                this.collector.Error(this.currentLine, this.currentPosition + 1);
                this.currentPosition++;
            }
        }

        private bool IsValidToken(string line)
        {
            return this.IsWhiteSpace(line) || this.IsSingleCharacterToken(line) || this.IsName(line);
        }

        /// <summary>
        /// Aligning lexer's start position to the first analyzable character in the line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool IsWhiteSpace(string line)
        {
            Match spaces = this.whitePattern.Match(line.Substring(this.currentPosition));

            if (spaces?.Success ?? false)
            {
                this.currentPosition += spaces.Length;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Matching next singe character token to the dedicated collector function.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool IsSingleCharacterToken(string line)
        {
            char token = line.ElementAt(this.currentPosition);

            Action<int, int> action = token switch
            {
                '{' => this.collector.OpenBrace,
                '}' => this.collector.ClosedBrace,
                '(' => this.collector.OpenParen,
                ')' => this.collector.ClosedParen,
                '<' => this.collector.OpenAngle,
                '>' => this.collector.ClosedAngle,
                '-' => this.collector.Dash,
                ':' => this.collector.Colon,
                _ => null,
            };

            if (action is not null)
            {
                action(this.currentLine, this.currentPosition);
                this.currentPosition++;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Aligning the lexer's position to the end of the name value.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private bool IsName(string line)
        {
            Match name = this.namePattern.Match(line.Substring(this.currentPosition));

            if (name?.Success ?? false)
            {
                this.collector.Name(name.Value, this.currentLine, this.currentPosition);
                this.currentPosition += name.Length;
                return true;
            }

            return false;
        }
    }
}

using FiniteStateMachine.FsmParser.Interfaces;

namespace FiniteStateMachine.UnitTests.Fixtures
{
    public class CollectorSelfShunt : ITokenCollector
    {
        private IList<string> _tokens = new List<string>();

        /// <summary>
        /// Getter of the spied calls of the collector.
        /// </summary>
        protected string SpyOutput
        {
            get => string.Join(',', this._tokens);
            private set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));

                this._tokens.Add(value);
            }
        }

        protected void Clear() => this._tokens.Clear();

        public void ClosedAngle(int line, int pos)
        {
            this.SpyOutput = "CA";
        }

        public void ClosedBrace(int line, int pos)
        {
            this.SpyOutput = "CB";
        }

        public void ClosedParen(int line, int pos)
        {
            this.SpyOutput = "CP";
        }

        public void Colon(int line, int pos)
        {
            this.SpyOutput = "C";
        }

        public void Dash(int line, int pos)
        {
            this.SpyOutput = "D";
        }

        public void Error(int line, int pos)
        {
            this.SpyOutput = $"ERROR:{line}/{pos}";
        }

        public void Name(string name, int line, int pos)
        {
            this.SpyOutput = $"#{name}#";
        }

        public void OpenAngle(int line, int pos)
        {
            this.SpyOutput = "OA";
        }

        public void OpenBrace(int line, int pos)
        {
            this.SpyOutput = "OB";
        }

        public void OpenParen(int line, int pos)
        {
            this.SpyOutput = "OP";
        }
    }
}

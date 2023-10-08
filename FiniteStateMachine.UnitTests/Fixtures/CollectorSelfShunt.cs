using FiniteStateMachine.FsmParser.Interfaces;
using FiniteStateMachine.UnitTests.Spies;

namespace FiniteStateMachine.UnitTests.Fixtures
{
    public class CollectorSelfShunt : ActionsSpy, ITokenCollector
    {
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

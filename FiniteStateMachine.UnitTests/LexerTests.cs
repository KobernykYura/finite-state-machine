using FiniteStateMachine.FsmParser;
using FiniteStateMachine.UnitTests.Fixtures;

namespace FiniteStateMachine.UnitTests
{
    public class LexerTests : CollectorSelfShunt, IDisposable
    {
        private Lexer lexer;

        public LexerTests() =>
            this.lexer = new Lexer(this);

        [Theory]
        [InlineData(" ", "")]
        [InlineData("{", "OB")]
        [InlineData("}", "CB")]
        [InlineData("(", "OP")]
        [InlineData(")", "CP")]
        [InlineData("<", "OA")]
        [InlineData(">", "CA")]
        [InlineData(":", "C")]
        [InlineData("-", "D")]
        [InlineData(".", "ERROR:1/1")]
        [InlineData("\n.\n", "ERROR:2/1")]
        [InlineData("Name", "#Name#")]
        [InlineData("N_am_e", "#N_am_e#")]
        public void ParsesSimpleStatementCorrectly(string input, string expected) =>
            this.AssertLexParsing(input, expected);

        [Theory]
        [InlineData("{ANYNAME}", "OB,#ANYNAME#,CB")]
        [InlineData("FSM:fsm{<this}", "#FSM#,C,#fsm#,OB,OA,#this#,CB")]
        [InlineData("FSM:fsm.\n{this}", "#FSM#,C,#fsm#,ERROR:1/8,OB,#this#,CB")]
        [InlineData("{}()<>-: name . ", "OB,CB,OP,CP,OA,CA,D,C,#name#,ERROR:1/15")]
        [InlineData(" \t\t \n\n- \t \t\n \n     ", "D")]
        [InlineData(" \t\t \n\n{ANYNAME} \t \t\n \n", "OB,#ANYNAME#,CB")]
        public void ParsesComplexStatementCorrectly(string input, string expected) =>
            this.AssertLexParsing(input, expected);

        /// <summary>
        /// Assertion over parsing of the provided input string.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expected"></param>
        private void AssertLexParsing(string input, string expected)
        {
            this.lexer.Lex(input);

            Assert.Equal(expected, this.SpyOutput);
        }

        public void Dispose() =>
            this.Clear();
    }
}

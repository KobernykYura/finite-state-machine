using FiniteStateMachine.FsmParser.Syntax;

namespace FiniteStateMachine.FsmParser
{
    /// <summary>
    /// Structural representation of the Finite State Machine, introduced by Uncle Bob.
    /// <FSM> ::= <header>* <logic>
    /// </summary>
    public class FsmSyntax
    {
        public IList<Header> Headers { get; set; }
        public IList<Transition> Logic { get; set; }

        public FsmSyntax()
        {
            
        }
    }
}
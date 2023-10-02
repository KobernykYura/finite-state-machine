namespace FiniteStateMachine.FsmParser.Syntax
{
    /// <summary>
    /// The transition of the given state to the next state.
    /// <code>
    ///     &lt;transition&gt; ::= &lt;state-spec> &lt;sub-transition&gt;
    ///                         | &lt;state-spec> "{" &lt;sub-transition&gt;* "}"
    /// </code>
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// Starting state of the transition.
        /// <code>
        ///     &lt;state&gt; ::= &lt;state-modifier&gt;*
        /// </code>
        /// </summary>
        public StateSpec State { get; set; }
        /// <summary>
        /// A sub-transition(s) defined for the given state.
        /// <code>
        ///     &lt;sub-transition&gt; ::= &lt;event&gt; &lt;next-state&gt; &lt;action&gt;
        /// </code>
        /// </summary>
        public IList<SubTransition> SubTransition { get; set; }
    }
}
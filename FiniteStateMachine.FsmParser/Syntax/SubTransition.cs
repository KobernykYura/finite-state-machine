namespace FiniteStateMachine.FsmParser.Syntax
{
    /// <summary>
    /// Structural representation of the next event followed by next stated followed by next action.
    /// <code>
    ///     &lt;sub-transition&gt; ::= &lt;event&gt; &lt;next-state&gt; &lt;action&gt;
    /// </code>
    /// </summary>
    public class SubTransition
    {
        /// <summary>
        /// Event of the given sub-transition.
        /// <code>
        ///     &lt;event&gt; ::= &lt;name&gt; | "-"
        /// </code>
        /// </summary>
        public string Event { get; set; }
        /// <summary>
        /// The next state of the given sub-transition on the given event.
        /// <code>
        ///     &lt;next-state&gt; ::= &lt;state&gt; | "-"
        /// </code>
        /// </summary>
        public string NextState { get; set; }
        /// <summary>
        /// The action(s) to be executed on the given event.
        /// <code>
        ///     &lt;action&gt; ::= &lt;name&gt; | "{" &lt;name&gt;* "}" | "-"
        /// </code>
        /// </summary>
        public IList<string> Actions { get; set; }

        public SubTransition(string _event)
        {
            this.Event = _event;
        }
    }
}
namespace FiniteStateMachine.FsmParser.Syntax
{
    public class StateSpec
    {
        /// <summary>
        /// Name of the dedicates state.
        /// <code>
        ///     &lt;state&gt; ::= &lt;name&gt; | "(" &lt;name&gt; ")"
        /// </code>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identifier of the state abstractness, allowing to use it as a base state.
        /// </summary>
        public bool AbstractState { get; set; }

        /// <summary>
        /// The state modifier of super state ":"
        /// <code>
        ///     &lt;state-modifier&gt; ::=
        ///                           ":" &lt;name&gt;
        ///                         | "&lt;" &lt;name&gt;
        ///                         | "&gt;" &lt;name&gt;
        /// </code>
        /// </summary>
        public string SuperState { get; set; }

        /// <summary>
        /// The state modifier of entry action "&lt;"
        /// <code>
        ///     &lt;state-modifier&gt; ::=
        ///                           ":" &lt;name&gt;
        ///                         | "&lt;" &lt;name&gt;
        ///                         | "&gt;" &lt;name&gt;
        /// </code>
        /// </summary>
        public string EntryAction { get; set; }

        /// <summary>
        /// The state modifier of exit action "&gt;"
        /// <code>
        ///     &lt;state-modifier&gt; ::=
        ///                           ":" &lt;name&gt;
        ///                         | "&lt;" &lt;name&gt;
        ///                         | "&gt;" &lt;name&gt;
        /// </code>
        /// </summary>
        public string ExitAction { get; set; }
    }
}
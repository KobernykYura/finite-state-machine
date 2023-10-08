namespace FiniteStateMachine.UnitTests.Spies
{
    public abstract class ActionsSpy
    {
        /// <summary>
        /// The list of tokens representing actions spied by the mock object.
        /// </summary>
        private IList<string> _tokens = new List<string>();

        /// <summary>
        /// Getter of the spied calls of the collector.
        /// </summary>
        protected string SpyOutput
        {
            get => string.Join(',', this._tokens);
            set
            {
                if (value is null)
                    throw new ArgumentNullException(nameof(value));

                this._tokens.Add(value);
            }
        }

        /// <summary>
        /// Clear the buffer of action tokens for the next run.
        /// </summary>
        protected void Clear() => this._tokens.Clear();
    }
}

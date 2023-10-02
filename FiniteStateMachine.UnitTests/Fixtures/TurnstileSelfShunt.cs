using FiniteStateMachine.StatePattern;
using FiniteStateMachine.StatePattern.States;

namespace FiniteStateMachine.UnitTests.Fixtures
{
    public class TurnstileSelfShunt : TurnstileFSM, IDisposable
    {
        protected string ActionsSpy = string.Empty;

        protected TurnstileFSM turnstile { get; }

        public TurnstileSelfShunt(Locked state) : base(state)
        {
            this.turnstile = this;
        }

        /// <summary>
        /// Action mock.
        /// </summary>
        public override void Lock() =>
            this.ActionsSpy += "L";

        /// <summary>
        /// Action mock.
        /// </summary>
        public override void Unlock() =>
            this.ActionsSpy += "U";

        /// <summary>
        /// Action mock.
        /// </summary>
        public override void Thanks() =>
            this.ActionsSpy += "T";

        /// <summary>
        /// Action mock.
        /// </summary>
        public override void Alarm() =>
            this.ActionsSpy += "A";

        public void Dispose()
        {
            this.ActionsSpy = string.Empty;
            TurnstileState.Await = new Await();
        }
    }
}

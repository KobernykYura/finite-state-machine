using FiniteStateMachine.StatePattern.Interfaces;

namespace FiniteStateMachine.StatePattern.States
{
    public abstract class TurnstileState : ITurnstileState
    {
        public static ITurnstileState Locked = new Locked();
        public static ITurnstileState Unlocked = new Unlocked();
        public static ITurnstileState Await = new Await();

        /// <summary>
        /// Event of putting a coin into turnstile to pass.
        /// </summary>
        /// <param name="turnstile"></param>
        public abstract void Coin(TurnstileFSM turnstile);

        /// <summary>
        /// Event of passing a turnstile.
        /// </summary>
        /// <param name="turnstile"></param>
        public abstract void Pass(TurnstileFSM turnstile);
    }
}

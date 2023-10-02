namespace FiniteStateMachine.StatePattern.Interfaces
{
    public interface ITurnstileState
    {
        /// <summary>
        /// Event of putting a coin into turnstile to pass.
        /// </summary>
        /// <param name="turnstile"></param>
        void Coin(TurnstileFSM turnstile);

        /// <summary>
        /// Event of passing a turnstile.
        /// </summary>
        /// <param name="turnstile"></param>
        void Pass(TurnstileFSM turnstile);
    }
}

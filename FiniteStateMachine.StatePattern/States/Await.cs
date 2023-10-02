namespace FiniteStateMachine.StatePattern.States
{
    /// <summary>
    /// Intermediate state requiring more coins to unlock the turnstile.
    /// </summary>
    public class Await : TurnstileState
    {
        /// <summary>
        /// Represents a number of coins put into turnstile to pass.
        /// </summary>
        private int coins;

        public override void Coin(TurnstileFSM turnstile)
        {
            this.coins++;

            if (this.IsEnoughCoins())
            {
                this.coins = default;
                turnstile.State = Unlocked;
                turnstile.Unlock();
            }
        }

        public override void Pass(TurnstileFSM turnstile)
        {
            turnstile.State = Locked;
            turnstile.Alarm();
        }

        private bool IsEnoughCoins()
        {
            return this.coins > 1;
        }
    }
}

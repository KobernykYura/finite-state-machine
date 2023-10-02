using FiniteStateMachine.StatePattern.Interfaces;

namespace FiniteStateMachine.StatePattern.States
{
    public class Unlocked : TurnstileState
    {
        public override void Coin(TurnstileFSM turnstile)
        {
            turnstile.Thanks();
        }

        public override void Pass(TurnstileFSM turnstile)
        {
            turnstile.State = Locked;
            turnstile.Lock();
        }
    }
}

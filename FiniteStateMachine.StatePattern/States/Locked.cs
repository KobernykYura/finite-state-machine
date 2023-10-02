namespace FiniteStateMachine.StatePattern.States
{
    public class Locked : TurnstileState
    {
        public override void Coin(TurnstileFSM turnstile)
        {
            turnstile.State = Await;
            turnstile.State.Coin(turnstile);
        }

        public override void Pass(TurnstileFSM turnstile)
        {
            turnstile.State = Locked;
            turnstile.Alarm();
        }
    }
}

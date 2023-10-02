using FiniteStateMachine.StatePattern.Interfaces;

namespace FiniteStateMachine.StatePattern
{
    public class TurnstileFSM : ITurnstile
    {
        public ITurnstileState State { get; set; }

        public TurnstileFSM(ITurnstileState state)
        {
            this.State = state;
        }

        public void Coin()
        {
            this.State.Coin(this);
        }

        public void Pass()
        {
            this.State.Pass(this);
        }

        public virtual void Unlock()
        {
            throw new NotImplementedException();
        }

        public virtual void Alarm()
        {
            throw new NotImplementedException();
        }

        public virtual void Thanks()
        {
            throw new NotImplementedException();
        }

        public virtual void Lock()
        {
            throw new NotImplementedException();
        }
    }
}
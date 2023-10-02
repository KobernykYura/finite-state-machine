using FiniteStateMachine.StatePattern.States;
using FiniteStateMachine.UnitTests.Fixtures;

namespace FiniteStateMachine.UnitTests
{
    public class TurnstileTests : TurnstileSelfShunt, IClassFixture<Locked>, IDisposable
    {
        public TurnstileTests(Locked state) : base(state) { }

        [Fact]
        public void OneCoinPartiallyUnlocksTurnstile()
        {
            this.turnstile.State = TurnstileState.Locked;

            this.turnstile.Coin();

            Assert.IsType<Await>(this.turnstile.State);
            Assert.Equal("", ActionsSpy);
        }

        [Fact]
        public void TwoCoinsUnlocksTurnstile()
        {
            this.turnstile.State = TurnstileState.Locked;

            this.turnstile.Coin();
            this.turnstile.Coin();

            Assert.IsType<Unlocked>(this.turnstile.State);
            Assert.Equal("U", ActionsSpy);
        }

        [Fact]
        public void MoreThanTwoCoinsUnlocksTurnstileAndSaysThankYou()
        {
            this.turnstile.State = TurnstileState.Locked;

            this.turnstile.Coin();
            this.turnstile.Coin();
            this.turnstile.Coin();

            Assert.IsType<Unlocked>(this.turnstile.State);
            Assert.Equal("UT", ActionsSpy);
        }

        [Fact]
        public void CoinSaysThanks()
        {
            this.turnstile.State = TurnstileState.Unlocked;

            this.turnstile.Coin();

            Assert.IsType<Unlocked>(this.turnstile.State);
            Assert.Equal("T", ActionsSpy);
        }

        [Fact]
        public void PassAlarms()
        {
            this.turnstile.State = TurnstileState.Locked;

            this.turnstile.Pass();

            Assert.IsType<Locked>(this.turnstile.State);
            Assert.Equal("A", ActionsSpy);
        }

        [Fact]
        public void PassSuccessful()
        {
            this.turnstile.State = TurnstileState.Unlocked;

            this.turnstile.Pass();

            Assert.IsType<Locked>(this.turnstile.State);
            Assert.Equal("L", ActionsSpy);
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
}
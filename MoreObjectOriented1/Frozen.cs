using System;

namespace MoreObjectOriented1
{
	class Frozen : IAccountState
	{
		private Action OnUnfreeze { get; }

		public Frozen(Action onUnfreeze)
		{
			this.OnUnfreeze = onUnfreeze;
		}

		public IAccountState Deposit(Action addToBalance)
		{
			this.OnUnfreeze();
			addToBalance();
			return new Active(this.OnUnfreeze);
		}

		public IAccountState Freese() => this;

		public IAccountState Withdraw(Action subtractMoney)
		{
			this.OnUnfreeze();
			subtractMoney();
			return new Active(this.OnUnfreeze);
		}

		public IAccountState HolderVerified() => this;

		public IAccountState Close() => new Closed();
	}
}

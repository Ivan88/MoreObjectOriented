using System;

namespace MoreObjectOriented1
{
	class NotVerified : IAccountState
	{
		private Action OnUnfreeze { get; }

		public NotVerified(Action onUnfreeze)
		{
			this.OnUnfreeze = onUnfreeze;
		}

		public IAccountState Close() => new Closed();

		public IAccountState Deposit(Action addBalance)
		{
			addBalance();
			return this;
		}

		public IAccountState Freese() => this;

		public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

		public IAccountState Withdraw(Action subtractMoney) => this;
	}
}

using System;

namespace MoreObjectOriented1
{
	class Closed : IAccountState
	{
		public IAccountState Close() => this;

		public IAccountState Deposit(Action addBalance) => this;

		public IAccountState Freese() => this;

		public IAccountState HolderVerified() => this;

		public IAccountState Withdraw(Action subtractFromBalance) => this;
	}
}

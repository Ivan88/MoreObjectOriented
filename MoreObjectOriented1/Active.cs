using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreObjectOriented1
{
	class Active : IAccountState
	{
		private Action OnUnfreeze { get; }

		public Active(Action onUnfreeze)
		{
			this.OnUnfreeze = onUnfreeze;
		}

		public IAccountState Deposit(Action add)
		{
			add();
			return this;
		}

		public IAccountState Freese() => new Frozen(OnUnfreeze);

		public IAccountState Withdraw(Action minus)
		{
			minus();
			return this;
		}

		public IAccountState HolderVerified() => this;

		public IAccountState Close() => new Closed();
	}
}

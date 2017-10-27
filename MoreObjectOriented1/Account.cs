using System;

namespace MoreObjectOriented1
{
	public class Account
	{
		public decimal Balance { get; private set; }

		private IAccountState State { get; set; }

		public Account(Action onUnfreeze)
		{
			State = new NotVerified(onUnfreeze);
		}

		public void Deposit(decimal money)
		{
			this.State = this.State.Deposit(() => this.Balance += money);
		}

		public void Withdraw(decimal money)
		{
			this.State = this.State.Withdraw(() => this.Balance -= money);
		}

		public void HolderVerified()
		{
			this.State = this.State.HolderVerified();
		}

		public void Close()
		{
			this.State = this.State.Close();
		}

		public void Freeze()
		{
			this.State = this.State.Freese();
		}
	}
}

using System;

namespace MoreObjectOriented1
{
	interface IAccountState
	{
		IAccountState Deposit(Action addBalance);
		IAccountState Withdraw(Action subtractFromBalance);
		IAccountState Freese();
		IAccountState HolderVerified();
		IAccountState Close();
	}
}

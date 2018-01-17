using DesignPatternCommand.Entity;

namespace DesignPatternCommand.Command
{
    public class WithdrawCommand : ITransaction
    {
        private readonly Account _account;
        private readonly decimal _amount;

        public WithdrawCommand(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        #region implémentation ITransaction
        public bool IsCompleted { get; set; }

        public void Execute()
        {
            if (_account.Balance >= _amount)
            {
                _account.Balance -= _amount;
                IsCompleted = true;
            }
        }
        #endregion
    }
}

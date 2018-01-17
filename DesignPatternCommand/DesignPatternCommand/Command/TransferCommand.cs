using DesignPatternCommand.Entity;
using System;

namespace DesignPatternCommand.Command
{

    class TransferCommand : ITransaction
    {
        private readonly Account _fromAccount;
        private readonly Account _toAccount;
        private readonly Decimal _amount;

        public TransferCommand(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;
            IsCompleted = false;
        }




        public bool IsCompleted
        {
            get;

            set;
        }

        public void Execute()
        {
            if (_fromAccount.Balance >= _amount)
            {
                _fromAccount.Balance -= _amount;
                _toAccount.Balance += _amount;
                IsCompleted = true;
            }
        }
    }
}

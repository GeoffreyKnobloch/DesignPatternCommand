using DesignPatternCommand.Command;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternCommand.Invoker
{
    /// <summary>
    /// Invoker de commande : La classe qui va executer les commandes, undo, retry, ..
    /// </summary>
    class TransactionManager
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();

        public bool HasPendingTransactions
        {
            get
            {
                return _transactions.Any(x => !x.IsCompleted);
            }
        }

        public void AddTransaction(ITransaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void ProcessPendingTransactions()
        {
            foreach (ITransaction transaction in _transactions.Where(x => !x.IsCompleted))
            {
                transaction.Execute();
            }
        }


    }
}

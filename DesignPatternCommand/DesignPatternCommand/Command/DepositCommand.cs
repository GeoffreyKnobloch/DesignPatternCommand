using DesignPatternCommand.Entity;

namespace DesignPatternCommand.Command
{
    /// <summary>
    /// Commande permettant de déposer de l'argent sur le compte
    /// </summary>
    public class DepositCommand : ITransaction
    {
        private readonly Account _account;
        private readonly decimal _amount;


        /// <summary>
        /// Constructeur prenant les paramètres de la commande
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        public DepositCommand(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;

            IsCompleted = false;
        }


        #region Implémentation de l'interface
        public bool IsCompleted
        {
            get;

            set;
        }

        /// <summary>
        /// Implémentation de l'éxécution de la commande
        /// </summary>
        public void Execute()
        {
            _account.Balance += _amount;
            IsCompleted = true;
        }
        #endregion
    }
}

namespace DesignPatternCommand.Command
{
    /// <summary>
    /// Interface que devra implémenter chaque commande
    /// </summary>
    interface ITransaction
    {
        /// <summary>
        /// La commande est complétée
        /// </summary>
        bool IsCompleted { get; set; }

        /// <summary>
        /// Execution de la commande
        /// </summary>
        void Execute();
    }
}

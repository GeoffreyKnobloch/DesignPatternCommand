namespace DesignPatternCommand.Entity
{
    /// <summary>
    /// Business object (entity) account
    /// </summary>
    /// <remarks>RECEIVER du design pattern Command : Il reçoit l'action de la commande</remarks>
    public class Account
    {
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }

        public Account(string ownerName, decimal balance)
        {
            OwnerName = ownerName;
            Balance = balance;
        }


    }
}

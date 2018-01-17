using DesignPatternCommand.Command;
using DesignPatternCommand.Entity;
using DesignPatternCommand.Invoker;
using System;

namespace DesignPatternCommand.Client
{
    class Program
    {
        /// <summary>
        /// Programme très simple qui n'a qu'un seul but : Implémenter le command Design pattern.
        /// Main est ici le Client qui va faire appel à l'invoker (transactionmanager) pour exécuter des Command
        /// qui vont agir sur le business Object (account)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                bool continuer = true;
                TransactionManager transactionManager = new TransactionManager();

                Account compteGeoffrey = new Account("Geoffrey", 20000);
                Account compteLorena = new Account("Lorena", 5000);

                // Ajout d'une commande :
                ITransaction commande;
                Console.WriteLine("Geoffrey a " + compteGeoffrey.Balance + "et Lorena a " + compteLorena.Balance);

                while (continuer)
                {
                    Console.WriteLine("Choisir une commande : W/D/T");
                    var cle = Console.ReadKey();
                    switch (cle.KeyChar)
                    {
                        case 'w':
                            Console.WriteLine("Ajout commande Withdraw sur compte Geoffrey de 500");
                            commande = new WithdrawCommand(compteGeoffrey, 500);
                            break;
                        case 'd':
                            Console.WriteLine("Deposit sur compte Lorena de 300");
                            commande = new DepositCommand(compteLorena, 300);
                            break;
                        case 't':
                            Console.WriteLine("Transfert de Lorena vers Geoffrey de 400");
                            commande = new TransferCommand(compteLorena, compteGeoffrey, 400);
                            break;
                        default:
                            throw new Exception();
                    }
                    transactionManager.AddTransaction(commande);

                    Console.WriteLine("Geoffrey a " + compteGeoffrey.Balance + "et Lorena a " + compteLorena.Balance);

                    Console.WriteLine("Executer les commandes ? (y/n)");
                    var executer = Console.ReadKey();
                    if (executer.KeyChar == 'y')
                    {
                        transactionManager.ProcessPendingTransactions();
                    }
                    Console.WriteLine("Geoffrey a " + compteGeoffrey.Balance + "et Lorena a " + compteLorena.Balance);

                    Console.WriteLine("Quitter ?(y/n)");
                    var quitter = Console.ReadKey();
                    if (quitter.KeyChar == 'y')
                    {
                        continuer = false;
                    }
                }

            }
            catch
            {
                Console.WriteLine("Mauvais input, programme fait à l'arrache dans le seul but d'implémenter le Command Design pattern, respecter la casse.");
                Console.ReadKey();
            }

        }
    }
}

/* 4 parties dans le Design Pattern Command :
 * 
 * 1 : La commande (ici Deposit, et Withdraw pour déposer et retirer de l'argent)
 * => Qui fait quelque chose
 * 2 : Le receveur (receiver) : Les business Object qui vont recevoir ce que la commande fait
 * => Business object qui reçoit ce que la commande fait
 * 3 : L'Invoqueur (invoker) : Il exécute la commande, mais aussi peut undo, retry, ...
 * => Qui execute, retry, undo la commande
 * 4 : Le client : Le programme qui va consommer ce design pattern (ici Main)
 * 
 * */

/*
* 
* Utilisation : Gros programme d'entreprise qui a besoin d'être bien scalable, évolutif
* Pour avoir de la visibilité sur les actions et surtout un moyen de les manager :
* Try, undo, Try again, IsExecuted ? IsSuccessfull ? IsError ? 
* 
* */


/* Une classe contenant deux méthodes qui s'éxécutent directement lorsqu'elles sont appelées (Contrairement aux commandes) :
* 
public class Account_NonCommand
{
public string OwnerName { get; set; }
public decimal Balance { get; set; }

public Account_NonCommand(string ownerName, decimal balance)
{
    OwnerName = ownerName;
    Balance = balance;
}

public void Deposit(decimal amount)
{
    Balance += amount;
}

public void Withdraw(decimal amount)
{
    if (amount > Balance)
    {
        throw new ArgumentOutOfRangeException("Overdraft error");
    }

    Balance -= amount;
}
}
*/



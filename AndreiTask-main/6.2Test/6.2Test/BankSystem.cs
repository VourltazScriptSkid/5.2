using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters;
/*
  
   Explain how inheritance and polymorphism are used in this solution
Inheritance and polymorphism are used in this solution throughout our DepositTransaction, WithdrawTransaction, TransferTransaction classes,in which implements a child and parent class system,
This allows us to create a new class from an existing class, being a key feature of OOP. Helping with code reusability, and maintaining same methods (behaviours).

   How can a single ExecuteTransaction method perform any kind of transaction?
  
ExecuteTransaction or Execute method can perform any kind of transaction as all the Execute methods all derive from the Transaction class, due to inheritance and polymorphism.

   What changes would you need to make to the Bank to include a new transaction type?

Inherite an new transaction type to the transfer class, as do all the same with Transfer,Deposit, and Withdraw. Along with its corresponding methods.
  
   What are the advantages we get through inheritance?

The advantages of inheritance is; code resuability, saves time and effort due to resuability, provides a clear model structure, less development
, ability to override methods of the bass class, inheritance also allows the ability to keep some data private so it can not be altered by derived class.

   What advantages does polymorphism provide?
The advantages of inheritance is; Code reusability, supports single variable names for multitude of data types, reduces coupling between functions.
  
 */

namespace _6._2Real
{

    public enum menu
    {
        Withdraw = 1,

        Deposit = 2,

        Transfer = 3,

        CreateAccount = 4,

        Print = 5,

        RollBack = 6,

        Quit = 7
    }

    public class BankSystem
    {
        
        static void Main(string[] arg)
        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Welcome to Hustlers University Banking!");
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");

            Bank bank = new Bank();
            Account main = new Account("James Charles", 100);
            bank.AddAccount(main);
          
        

            int option1;
            do
            {
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("Please choose an banking option: ");
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                foreach (menu choices in Enum.GetValues(typeof(menu)))

                {

                    Console.WriteLine("-{0}. {1}", (int)choices, choices);

                }
                Console.Write("Select an option: ");     // Returns the option of menu back to the account as it is menu
                option1 = Convert.ToInt32(Console.ReadLine());
                menu option = (menu)option1;

                switch (option)
                {
                    case menu.Withdraw:

                        DoWithdraw(bank);

                        break;

                    case menu.Deposit:

                        DoDeposit(bank);

                        break;

                    case menu.Transfer:

                        DoTransfer(bank);

                        break;

                    case menu.CreateAccount:

                        CreateAccount(bank);

                        break;

                    case menu.Print:

                        DoPrint(bank);

                        break;

                    case menu.RollBack:

                        DoRollback(bank);

                        break;

                    case menu.Quit:

                        Console.WriteLine("Goodbye! " +
                            "Closing Down Hustler's University Banking!");
                        Environment.Exit(0);

                        break;

                    default:
                        Console.WriteLine("Bruh That's not even an option maneeee, are you serious right neeyowew [Forcing System To Close Down]");
                      
                        break;
                }

            } while (option1 <= 0 || option1 < Enum.GetValues(typeof(menu)).Length);
            
            Console.Read();

        }

       
        

        public static int ChoiceToInt(string ConvertIntToString)
        {
            int chosenNumber;
            while (!int.TryParse(ConvertIntToString, out chosenNumber))
            {
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("This is not a valid selection of number.");
                ConvertIntToString = Console.ReadLine();
                Console.WriteLine("Goodbye! Closing Down Hustler's University Banking! Please try again.");
                Environment.Exit(0);
            }
            return chosenNumber;


        }
        public static decimal ChoiceToDecimal(string ConvertNumberToString)
        {
            decimal chosenNumber;
            while (!decimal.TryParse(ConvertNumberToString, out chosenNumber))
            {
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("This is not a valid selection of number.");
                ConvertNumberToString = Console.ReadLine();
                Console.WriteLine("Goodbye! Closing Down Hustler's University Banking! Please try again.");
                Environment.Exit(0);
            }
            return chosenNumber;

            
        }

        public static bool YON(string message)
        {
            Console.WriteLine(message);
            string proceed;
            do
            {
                proceed = Console.ReadLine().ToLower();
                switch (proceed)
                {
                    case "y":
                        {
                            return true;
                        }
                    case "n":
                        {
                            return false;
                        }
                    default:
                        {
                            Console.WriteLine("That is not a valid option, please try again");
                            proceed = Console.ReadLine().ToLower();
                            break;
                        }
                }
            } while (proceed != "y" && proceed != "n" && string.IsNullOrEmpty(proceed));
            return false;
        }
        public static Transaction PickTransaction(Bank bank)
        {
            Console.WriteLine("Input the index of transaction: ");
            int inputIndex;

            do
            {
                inputIndex = ChoiceToInt(Console.ReadLine());
                if (inputIndex < 0 || inputIndex >= bank.Transactions.Count)
                {
                    Console.WriteLine("Index has not been found.");
                }
            } while (inputIndex < 0 || inputIndex >= bank.Transactions.Count);

            return bank.Transactions[inputIndex];
            


        }

        private static Account FindAccount(Bank bank)
        {
            Console.WriteLine("Enter account's name within our Banking System: ");
            Account search = bank.Search(Console.ReadLine());
            if (search != null)
            {
                Console.WriteLine("Search result:");
                search.Print();
            }
            else
            {
                
                Console.WriteLine("The account within our system can not be found");
            }
            return search;
        }

        public static void CreateAccount(Bank bank)
        {
            Console.WriteLine("Please Enter Your Opening Account Name: ");
            string accountName = Console.ReadLine();
            Console.WriteLine("Please Enter Your Starting Account Balance: ");
            decimal accountBalance = ChoiceToDecimal(Console.ReadLine());

            bank.AddAccount(new Account(accountName, accountBalance));
        }


        public static void DoDeposit(Bank bank)
        {

            Account account = FindAccount(bank);
  
            if (account != null)
            {
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("Input amount to Deposit: ");
                decimal amount = ChoiceToDecimal(Console.ReadLine());
                DepositTransaction currentTransaction = new DepositTransaction(account, amount);


       
                if (YON("Would you like to continue?  Y/N"))
                {
                    bank.ExecuteTransaction(currentTransaction);
                }
                else
                {
                    Console.WriteLine("Transaction has cancelled");
                }

        

                if (YON("Would you like to print the transaction details? Y/N"))
                {
                    currentTransaction.Print();
                }
            }
            else
            {
                Console.WriteLine("Deposit has been cancelled!");
            }

            Console.ReadLine();
        }

        public static void DoWithdraw(Bank bank)
        {
    
            Account account = FindAccount(bank);

            if (account != null)
            {
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("Input amount to Withdraw: ");
                decimal amount = ChoiceToDecimal(Console.ReadLine());
                WithdrawTransaction currentTransaction = new WithdrawTransaction(account, amount);


     
                if (YON("Would you like to proceed with the transaction details? Y/N"))
                {
                    bank.ExecuteTransaction(currentTransaction);
                }
                else
                {
                    Console.WriteLine("Transaction has been cancelled");
                }



                if (YON("Would you like to print the transaction details? Y/N"))
                {
                    currentTransaction.Print();
                }
            }
            else
            {
                Console.WriteLine("Withdrawal has been cancelled.");
            }

            Console.ReadLine();

        }

        public static void DoTransfer(Bank bank)
        {
   
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("From account: ");
            Account fromAccount = FindAccount(bank);
            if (fromAccount == null)
            {
                Console.WriteLine("Transfer has been cancelled!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("To account: ");
            Account toAccount = FindAccount(bank);

            if (fromAccount != null && toAccount != null)
            {
                Console.WriteLine("Input amount");
                decimal amount = ChoiceToDecimal(Console.ReadLine());
                TransferTransaction currentTransaction = new TransferTransaction(fromAccount, toAccount, amount);


                if (YON("Would you like to continue? Y/N"))
                {
                    bank.ExecuteTransaction(currentTransaction);
                }
                else
                {
                    Console.WriteLine("Transaction has been cancelled.");
                }

   

                if (YON("Would you like to print the transaction details? Y/N"))
                {
                    currentTransaction.Print();
                }
            }
            else
            {
                Console.WriteLine("Transfer has been cancelled.");
            }

            Console.ReadLine();
        }

        public static void DoPrint(Bank bank)
        {
            Account account = FindAccount(bank);
            if (account != null)
            {
                account.Print();
            }
            Console.ReadLine();
        }


        public static void DoRollback(Bank bank)
        {
            bank.PrintTransactionHistory();
            Console.WriteLine("Which transaction would you like to rollback?");
            Transaction transaction = PickTransaction(bank);
            bank.RollbackTransaction(transaction);
        }


    }
}

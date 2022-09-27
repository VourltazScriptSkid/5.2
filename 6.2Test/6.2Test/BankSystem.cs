using System;
/*
   Explain how the Bank works when you have multiple accounts.

Bank works with multiple bank accounts through a list within the Bank class that we have just implemented,
this sorts and looks for created objects within the list, and lets the program to normally process the methods when called upon
from the previous task 5.2.


   Explain how FindAccount works in relation to DoDeposit, DoWithdraw, and DoTransfer. What
   happens if the requested account cannot be found in any of these methods?

The methods will return with a Invalid operation exception, giving us error messages.

 */



namespace _6._2Real
{

    public enum menu
    {
        Withdraw = 1,

        Deposit = 2,

        Transfer = 3,

        AddAccount = 4,

        Print = 5,

        Quit = 6
    }

    class BankSystem
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Welcome to Hustlers University Banking!");
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Bank bank = new Bank();
            Account Andrew = new Account(1000, "Andrew Tate");
        

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

                    case menu.AddAccount:

                        bank.AddAccount(GetAccount());

                        break;

                    case menu.Print:

                        DoPrint(bank);

                        break;

                    case menu.Quit:

                        Console.WriteLine("Goodbye! " +
                            "Closing Down Hustler's University Banking!");
                        Environment.Exit(0);

                        break;

                    default:
                        Console.WriteLine("Bruh That's not even an option maneeee, are you serious right neeyowew [Forcing System To Close Down]");
                        Andrew.Quit();
                        break;
                }

            } while (option1 <= 0 || option1 < Enum.GetValues(typeof(menu)).Length);
            Console.Read();

        }

        // This method will create a new account within the Account List Class. 
        static Account GetAccount()

        {

            Console.WriteLine("Please Enter Your Opening Account Name: ");

            string name = Console.ReadLine();

            Console.WriteLine("Please Enter Your Starting Account Balance: ");

            decimal balance = Convert.ToDecimal(Console.ReadLine());

            return new Account(balance, name);

        }


        // This method is the FindAccount which will find the account that is created within the Account List Class.
        static Account FindAccount(Bank bank)

        {

            Console.WriteLine("Enter account's name within our Banking System: ");

            string name = Console.ReadLine();

            var account = bank.GetAccount(name);

            if (account == null)

            {

                Console.WriteLine("The account with the name: " + name + " can not be found");

            }

            return account;

        }
        // This method is the DoWithdrawal which makes the withdrawal on the account.
        static void DoWithdraw(Bank bank)

        {

            var account = FindAccount(bank);

            if (account == null)

                return;
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Input amount to Withdraw: ");

            decimal amount = Convert.ToDecimal(Console.ReadLine());

            WithdrawTransaction withdrawTransaction = new WithdrawTransaction(account, amount);

            bank.ExecuteTransaction(withdrawTransaction);

        }
        // This method is the DoDeposit which makes the deposit on the account.
        static void DoDeposit(Bank bank)

        {

            var account = FindAccount(bank);

            if (account == null)

                return;
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Input amount to Deposit: ");

            decimal amount = Convert.ToDecimal(Console.ReadLine());

            DepositTransaction depositTransaction = new DepositTransaction(account, amount);

            bank.ExecuteTransaction(depositTransaction);

        }
        // This method is the DoTransfer which makes the withdrawal on the account.
        static void DoTransfer(Bank bank)

        {

            Console.WriteLine("From Account:");

            var fromAccount = FindAccount(bank);

            if (fromAccount == null)

                return;

            Console.WriteLine("To Account:");

            var toAccount = FindAccount(bank);

            if (toAccount == null)

            {

                return;

            }
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Input amount to Transfer: ");

            decimal amount = Convert.ToDecimal(Console.ReadLine());

            TransferTransaction transferTransaction = new TransferTransaction(toAccount, fromAccount, amount);

            bank.ExecuteTransaction(transferTransaction);

        }
        // This method prints the account, which the call Print() function of the account class
        static void DoPrint(Bank bank)

        {

            var account = FindAccount(bank);

            if (account != null)

            {

                account.Print();

            }

            else

            {
                Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                Console.WriteLine("Account can't found");

            }

        }




    }
}

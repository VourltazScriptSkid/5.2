using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Explain how the classes can define different roles for objects to play, how does this relate to abstraction, the core OOP principle:
 * 
 * Abstraction is detail hiding in which we implment hiding, Whiles the principle of enscapulation groups together data and methods and acts on the data,
 * Abstraction deals with exposing the user and hiding the details of implementation, there are many advantages of abstraction in in which,
 * reduces the complexity of viewing things, avoids code duplication and increases resuability, and helps to increase the security of a program as important details
 * are provided to the user.
 * 
 * How does encapsulation relate to the TransferTransaction class? From an external perspective do we know/care that it uses other objects internally to perform tasks on its behalf.
 * 
 * Encapsulation is a way to put methods and variables togther, in which can also be said that encapsulation helps us keep states (variables) and behaviours (methods) together
 * Encapsulation also prevents the direct access to variables and methods by an  outsider, 
 * As for to relation of TransferClass, Print() method that is abstained within, we do not need to worry about internal details, as only we care about the final output, therefore
 * we dont not need to know the internal implementation details.
 * 
 */ 


// create Enumerations of the 5 tasks
public enum menu

{

    Withdraw = 1,

    Deposit = 2,

    Transfer = 3,

    Print = 4,

    Quit = 5

}

namespace BankSystem
{
    class BankSystem
    {

        // The Main method of execution
        static void Main(string[] args)
        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Welcome to Hustlers University!");
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Account Account1 = new Account("Andrei Angeles", 1000);
            Account Account2 = new Account("James Charles", 1000);

            Console.WriteLine("Current Banking Accounts: ");
            DoPrint(Account1, Account2);

            int option1;
            //prints the UI
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

                        {

                            Console.WriteLine(Convert.ToString(option));

                            DoWithdraw(Account1);

                            break;

                        }
                    case menu.Deposit:

                        {

                            Console.WriteLine(Convert.ToString(option));

                            DoDeposit(Account1);

                            break;

                        }

                  
                    case menu.Transfer:

                        {

                            Console.WriteLine(Convert.ToString(option));
                            Console.WriteLine("Transferring from Andrei's Account to James");

                            DoTransfer(Account1, Account2);

                            break;

                        }

                    case menu.Print:

                        {

                            Console.WriteLine(Convert.ToString(option));

                            DoPrint(Account1, Account2);

                            break;

                        }

                    case menu.Quit:

                        {

                            Console.WriteLine(Convert.ToString(option));

                            break;

                        }
                    default:
                        {
                            Console.WriteLine("Bruh That's not even an option maneeee, are you serious right neeyowew");
                            break;
                        }

                }
            } while (option1 <= 0 || option1 < Enum.GetValues(typeof(menu)).Length);
            Console.Read();
        }


        // This method is the DoDeposit which makes the deposit on the account.

        static void DoDeposit(Account account)

        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Input amount to Deposit into Andrei's Account: ");
            
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount < 0) { Console.WriteLine("Depositing Amount Can Not Be Negative"); return; }
            DepositTransaction DepositTransc = new DepositTransaction(account, amount);
            DepositTransc.Execute();
            DepositTransc.print();
        }
        // This method is the DoWithdrawal which makes the withdrawal on the account.
        static void DoWithdraw(Account account)

        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.Write("Input amount to Withdraw from Andrei's Account: ");
            
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount < 0) { Console.WriteLine("Withdrawing Amount Can Not Be Negative"); return; }
            WithdrawTransaction WithdrawTransc = new WithdrawTransaction(account, amount);
            WithdrawTransc.Execute();
            WithdrawTransc.print();
        }
        // This method is the DoTransfer which makes the withdrawal on the account.
        static void DoTransfer(Account OriginalAcc, Account NewAccount)

        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine("Input amount to Transfer: ");
        
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount < 0) { Console.WriteLine("Transferring Amount Can Not Be Negative"); return; }
            TransferTransaction TransferTransc = new TransferTransaction(OriginalAcc, NewAccount, amount);
            TransferTransc.Execute();
            TransferTransc.print();
        }
        // This method prints the account, which the call Print() function of the account class
        static void DoPrint(Account account1, Account account2)

        {
            Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            account1.Print();
            account2.Print();
      

        }
    }

}
using System;

namespace _6._2Real

{

    class Account

    {
        public decimal Balance { get; set; }
        public string Name { get; set; }
        public Account(decimal balance, string name)

        {

            Balance = balance;

            Name = name;

        }

        public bool Deposit(decimal amount)

        {

            if (amount <= 0)

            {

                Console.WriteLine("Deposit was not successful, Please try again.");

                return false;

            }

            Balance += amount;

            Console.WriteLine("The new balance within the account is: " + Balance);

            return true;

        }

        public bool Withdraw(decimal amount)

        {

            if (amount <= 0 || amount > Balance)

            {

                Console.WriteLine("Withdraw was not successful, Please try again.");

                return false;

            }

            Balance -= amount;

            Console.WriteLine("The new balance is " + Balance);

            return true;

        }

        public void Print()

        {

            Console.WriteLine("This Account is under: " + Name);
            Console.WriteLine("The Balance within this account is: " + Balance);


        }

        public void Quit()

        {

            Environment.Exit(0);

        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Account
    {
        private decimal _balance;

        private String _name;

        public Account(String name, decimal balance)

        {

            this._balance = balance;

            this._name = name;

        }

        //Accessor methods

        public void Print()

        {

            Console.WriteLine("Account name: " + this._name);

            Console.WriteLine("Available balance: " + this._balance);

        }

        public String Name() => this._name;

        public Decimal Balance() => this._balance;
        public void setBalace(decimal amount)
        {
            this._balance = amount;
        }

        //Mutator methods

        public bool Deposit(decimal ammount)

        {

            bool deposited = false;

            if (ammount < 0)

            {

                Console.WriteLine("The Depositing Amount Can Not Be Negative");

                deposited = false;

            }

            else if (ammount >= 0)

            {

                this._balance += ammount;

                deposited = true;

            }

            return deposited;

        }

        public bool Withdraw(decimal ammount)

        {

            bool withdraw = false;

            if (ammount < 0)

            {

                Console.WriteLine("The Withdrawing Amount Can Not Be Negative");

                withdraw = false;

            }

            else if (ammount > this._balance)

            {

                Console.WriteLine("You Can Not Withdraw More Than The Amount Within The Balance");

            }

            else

            {

                this._balance -= ammount;

                withdraw = true;

            }

            return withdraw;

        }
    }
}
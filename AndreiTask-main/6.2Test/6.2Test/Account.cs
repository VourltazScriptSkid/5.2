using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters;

namespace _6._2Real
{
    public class Account
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
            Console.WriteLine("The Account's name: " + this._name);
            Console.WriteLine("The Available balance: " + this._balance);
        }
        public String Name => _name;
        public decimal Balance => _balance;

        //Mutator methods
        public bool Deposit(decimal amount)
        {
            bool deposited = false;
            if (amount < 0)
            {
                Console.WriteLine("The depositing amount can not be negative");
                deposited = false;
            }
            else if (amount >= 0)
            {
                this._balance += amount;
                deposited = true;
            }
            return deposited;
        }

        public bool Withdraw(decimal amount)
        {
            bool withdraw = false;
            if (amount < 0)
            {
                Console.WriteLine("The deposit amount must not be negative");
                withdraw = false;
            }
            else if (amount > this._balance)
            {
                Console.WriteLine("You can not withdraw more than your available balance!");
            }
            else
            {
                this._balance -= amount;
                withdraw = true;
            }
            return withdraw;
        }


    }
}

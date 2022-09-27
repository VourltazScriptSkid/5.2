using System;
using System.Collections.Generic;
using System.Text;

namespace _6._2Real
{
     class DepositTransaction : Transaction
    {
        private Account _account;
  
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            this._amount = amount;
            this._account = account;
        }

        public override string Type => "Deposit Transaction";

        public override bool Success => _success;

        public override void Print()
        {
            Console.WriteLine($"Account name: {this._account.Name}");
            Console.WriteLine($"Amount to deposit: {this._amount.ToString("C")}");
            Console.Write("Status: ");
            if (this._success == true)
            {
                Console.WriteLine("Success!");
            }
            else if (this._success == false)
            {
                Console.WriteLine("End.");
            }

            Console.WriteLine($"Available funds: {this._account.Balance.ToString("C")}\n");
        }


        public override void Execute()
        {
            if (this._executed == true)
            {
                throw new InvalidOperationException("The transaction has already been attempted.");
            }
            if (this._amount <= 0)
            {
                this._executed = false;
                throw new InvalidOperationException("You can not deposit a negative amount.");
            }
            else if (this._amount > 0)
            {
   
                this._success = this._account.Deposit(_amount);
                this._executed = true;
                this._dateStamp = DateTime.Now;
            }
        }

        public override void Rollback()
        {
            if (this._reversed == true)
            {
                throw new InvalidOperationException("The transaction has been reversed.");
            }
            else if (this._executed == false)
            {
                throw new InvalidOperationException("The transaction has can not be executed.");
            }
            else if (this._executed == true && this._reversed == false)
            {
                this._account.Withdraw(_amount);
                this._reversed = true;
                this._dateStamp = DateTime.Now;
            }
        }


    }
}

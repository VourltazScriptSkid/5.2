using System;
using System.Dynamic;

namespace _6._2Real
{
    public class WithdrawTransaction : Transaction
    {
        private Account _account;

        private bool _executed;

        private bool _reversed;

        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public override string Type => "Withdraw Transaction";

        public override bool Success => _success;

        public override void Print()
        {
            Console.WriteLine($"Account name: {this._account.Name}");
            Console.WriteLine($"Amount to withdraw: {this._amount.ToString("C")}");
            Console.Write("Status: ");
            if (this._success == true)
            {
                Console.WriteLine("Success!");
            }
            else if (this._success == false)
            {
                Console.WriteLine("Dipping");
            }

            Console.WriteLine($"Available fund: {this._account.Balance.ToString("C")}\n");
        }

        public override void Execute()
        {
            if (this._executed == true)
            {
                throw new InvalidOperationException("The transaction has already been attempted.");
            }
            else if (this._account.Balance < this._amount)
            {
                this._executed = false;
                throw new InvalidOperationException("There is Insufficient funds within the account!");
            }
            else if (this._executed == false && this._account.Balance >= this._amount)
            {
                this._success = this._account.Withdraw(_amount);
                this._executed = true;
                this._dateStamp = DateTime.Now;
            }
        }

        public override void Rollback()
        {
            if (this._reversed == true)
            {
                throw new InvalidOperationException("The transaction has already been reversed");
            }
            else if (this._executed == false)
            {
                throw new InvalidOperationException("The transaction can not be executed");
            }
            else if (this._executed == true && this._reversed == false)
            {
                this._account.Deposit(_amount);
                this._reversed = true;
                this._dateStamp = DateTime.Now;
            }
        }
    }
}
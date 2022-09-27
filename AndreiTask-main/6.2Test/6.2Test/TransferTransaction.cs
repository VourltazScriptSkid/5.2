using System;
using System.Collections.Generic;
using System.Text;

namespace _6._2Real
{

    public class TransferTransaction : Transaction
    {
        private Account _fromAccount, _toAccount;

        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        bool _executed, _reversed;
        public override string Type => "Transfer Transaction";

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {
            this._fromAccount = fromAccount;
            this._toAccount = toAccount;
            this._amount = amount;
            this._withdraw = new WithdrawTransaction(_fromAccount, this._amount);
            this._deposit = new DepositTransaction(_toAccount, this._amount);
        }

        public bool Successful
        {
            get
            {
                if (this._withdraw.Success && this._deposit.Success)
                    return true;
                return false;
            }
        }

        public override bool Success => throw new NotImplementedException();

        public override void Print()
        {
            Console.WriteLine($"Transfer {_amount.ToString("C")} from {_fromAccount.Name} to {_toAccount.Name}\n");
            _withdraw.Print();
            _deposit.Print();
        }

        public override void Execute()
        {
            if (this._executed == true)
            {
                throw new InvalidOperationException("The transaction has already been attempted.");
            }
            else if (this._fromAccount.Balance < this._amount)
            {
                this._executed = false;
                throw new InvalidOperationException("There is Insufficient funds within the account!");
            }
            else if (this._executed == false && this._fromAccount.Balance >= this._amount)
            {
                this._withdraw.Execute();
                this._deposit.Execute();
                if (!_deposit.Success)
                {
                    this._withdraw.Rollback();
                }

            }
        }

        public override void Rollback()
        {
            if (this._reversed)
            {
                throw new OperationCanceledException("The transaction has already been reversed.");
            }
            else if (this._fromAccount.Balance < this._amount)
            {
                throw new OperationCanceledException("There is insufficient funds to reverse the transaction.");
            }
            else if (!this.Successful)
            {
                throw new OperationCanceledException("The transaction has can not be completed.");
            }
            else if (this.Successful)
            {
                this._withdraw.Rollback();
                this._deposit.Rollback();
                this._reversed = true;
            }
        }
    }
}

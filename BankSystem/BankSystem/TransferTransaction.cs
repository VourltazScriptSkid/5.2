using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class TransferTransaction
    {
        private Account _fromaccount;
        private Account _toaccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;
        public Boolean Executed() => this._executed;
        public Boolean Success() => this._success;
        public Boolean Reveresed() => this._reversed;
        public TransferTransaction(Account fromaccount, Account toaccount, decimal amount)
        {
            this._fromaccount = fromaccount;
            this._toaccount = toaccount;
            this._amount = amount;
            _deposit = new DepositTransaction(toaccount, amount);
            _withdraw = new WithdrawTransaction(fromaccount, amount);
        }
        //Print Method
        public void print()
        {
            Console.WriteLine("Transferred " + _amount + " from " + _fromaccount.Name() + "\'s account To " + _toaccount.Name() + "\'s account");
        }
        //Execute Method
        public void Execute()
        {
            _withdraw.Execute();
            _deposit.Execute();
            if (_withdraw.Success() && _deposit.Success())
                _success = true;
            _executed = true;

        }
        //Rollback Method
        public void Rollback()
        {
            try
            {
                if (Success() && !Reveresed())
                {
                    throw new InvalidOperationException("Original Transaction has not been processed");
                }
                _deposit.Rollback();
                _withdraw.Rollback();
                _reversed = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
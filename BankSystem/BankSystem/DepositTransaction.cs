using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;
        public Boolean Executed() => this._executed;
        public Boolean Success() => this._success;
        public Boolean Reveresed() => this._reversed;

        public DepositTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        //Print Method
        public void print()
        {
            if (_success)
            {
                Console.WriteLine(_amount + " has been deposited to " + _account.Name() + "\'s account");
            }
        }

        //Execute Method
        public void Execute()
        {
            decimal bal = _account.Balance();
            try
            {
                if (_executed)
                {
                    throw new InvalidOperationException("Transaction has been attempted");
                }
                else
                {
                    bal = bal + _amount;
                    _account.setBalace(bal);
                    _success = true;
                }
                _executed = true;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
            }
        }
        //Rollback Method
        public void Rollback()
        {
            decimal bal = _account.Balance();
            try
            {
                if (Success() && !Reveresed())
                {
                    bal = bal - _amount;
                    _account.setBalace(bal);
                    _reversed = true;
                }
                else
                {
                    throw new InvalidOperationException("Original Transaction has not been processed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}

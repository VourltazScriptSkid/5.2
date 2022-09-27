using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        // Methods of ReadONLY
        public Boolean Executed() => this._executed;
        public Boolean Success() => this._success;
        public Boolean Reveresed() => this._reversed;
        public WithdrawTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }
        //Print Method
        public void print()
        {
            if (_success)
            {
                Console.WriteLine(_amount + "  has been withdrawn from " + _account.Name() + "\'s account");
            }
        }
        //Execute Method
        public void Execute()
        {
            decimal balance = _account.Balance();
            try
            {
                if (_executed)
                {
                    throw new InvalidOperationException("Transaction has been attempted");
                }
                if (_amount > balance)
                {
                    _success = false;
                    throw new InvalidOperationException("Operation Failed :: Unable to withdraw amount");

                }
                else
                {
                    balance = balance - _amount;
                    _account.setBalace(balance);

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
            decimal balance = _account.Balance();
            try
            {
                if (Success() && !Reveresed())
                {
                    balance = balance + _amount;
                    _account.setBalace(balance);
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
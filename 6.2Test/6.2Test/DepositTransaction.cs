using System;

namespace _6._2Real

{

    class DepositTransaction

    {
        private Account _account;
        public decimal _amount;
        public bool _executed;
        public bool _success;
        public bool _reversed;
        public bool Executed { get { return _executed; } }
        public bool Success { get { return _success; } }
        public bool Reversed { get { return _reversed; } }
        public DepositTransaction(Account account, decimal amount)

        {

            this._account = account;

            this._amount = amount;

        }

        public void Print()

        {

            Console.WriteLine("Deposit was Successful: " + Executed);
            Console.WriteLine(_amount + ": Has been deposited to " + _account.Name);


        }

        public void Rollback()

        {

            try

            {

                if (Success == false)

                {

                    throw new InvalidOperationException("Transaction was not successful");

                }

                if (Reversed)

                {

                    throw new InvalidOperationException("Original Transaction has not been processed");

                }

                else

                {

                    _account.Balance -= _amount;

                    _reversed = true;

                }

            }

            catch (InvalidOperationException ex)

            {

                Console.WriteLine("The following error detected: " + ex.GetType().ToString() + " with message \"" + ex.Message + "\"");

            }

        }

        public void Execute()

        {

            try

            {

                if (_amount < 0)

                {

                    throw new InvalidOperationException("Please enter valid amount");

                }

                if (Executed)

                {

                    throw new InvalidOperationException("Transaction already attempted");

                }

                else

                {

                    _account.Balance += _amount;

                    _success = true;

                    _executed = true;

                    Print();

                }

            }

            catch (InvalidOperationException e)

            {

                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");

            }

        }

    }

}
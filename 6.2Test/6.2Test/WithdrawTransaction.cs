using System;
namespace _6._2Real

{

    class WithdrawTransaction

    {

        private Account _account;
        public decimal _amount;
        public bool _executed;
        public bool _success;
        public bool _reversed;
        public bool Executed { get { return _executed; } }
        public bool Success { get { return _success; } }
        public bool Reversed { get { return _reversed; } }
        public WithdrawTransaction(Account account, decimal amount)

        {

            this._account = account;

            this._amount = amount;

        }

        public void Print()

        {

            Console.WriteLine("Transaction Successful: " + Executed + "\nWithdrawn: " + _amount +

            " from " + _account.Name);
            Console.WriteLine("Withdraw was Successful: " + Executed);
            Console.WriteLine(_amount + ": Has been Withdrawn from " + _account.Name);


        }

        public void Rollback()

        {

            try

            {

                if (Success == false)

                {

                    throw new InvalidOperationException("Transaction not successful");

                }

                if (Reversed)

                {

                    throw new InvalidOperationException("This operation cannot be done again");

                }

                else

                {

                    _account.Balance += _amount;

                    _reversed = true;

                }

            }

            catch (InvalidOperationException e)

            {

                Console.WriteLine("The following error detected: " + e.GetType().ToString()  + " with message \"" + e.Message + "\"");

            }

        }

        public void Execute()

        {

            try

            {

                if (_amount > _account.Balance)

                {

                    throw new InvalidOperationException("Insufficient funds");

                }

                if (Executed)

                {

                    throw new InvalidOperationException("Transaction had already been attempted");

                }

                if (_amount < 0)

                {

                    throw new InvalidOperationException("Please enter a valid amount");

                }

                else

                {

                    _account.Balance -= _amount;

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
using System;

namespace _6._2Real

{

    class TransferTransaction

    {

        private Account _toaccount, _fromaccount;
        public decimal _amount;
        public bool _executed;
        public bool _success;
        public bool _reversed;
        public bool Executed { get { return _executed; } }
        public bool Success { get { return _success; } }
        public bool Reversed { get { return _reversed; } }
        public TransferTransaction(Account toaccount, Account fromaccount, decimal amount)
        {

            this._toaccount = toaccount;

            this._fromaccount = fromaccount;

            this._amount = amount;

        }

        public void Print()

        {

            Console.WriteLine("Transfer was Successful: " + Executed);
            Console.WriteLine(_amount + ": Has been transferred from " +_fromaccount + " to " + _toaccount.Name);

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

                    throw new InvalidOperationException("This operation can't be done again");

                }

                if (_amount > _toaccount.Balance)

                {

                    throw new InvalidOperationException("The " + _toaccount.Name + " account does not have the succifient amount of funds");

                }

                else

                {

                    WithdrawTransaction depositRollback = new WithdrawTransaction(_toaccount, _amount);

                    // Call execute method to withdraw the amount from toaccount

                    depositRollback.Execute();

                    DepositTransaction withdrawRollback = new DepositTransaction(_fromaccount, _amount);

                    // Call execute method to deposit the amount to fromaccount

                    withdrawRollback.Execute();

                    _reversed = true;

                }

            }

            catch (InvalidOperationException e)

            {

                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");

            }

        }

        public void Execute()

        {

            try

            {

                if (_amount > _fromaccount.Balance)

                {

                    throw new InvalidOperationException("Insufficient funds");

                }

                if (Executed)

                {

                    throw new InvalidOperationException("Transaction had already been attempted");

                }

                else

                {

                    WithdrawTransaction withdrawTransaction = new WithdrawTransaction(_fromaccount, _amount);

                    withdrawTransaction.Execute();

                    // If withdraw transaction is successful, do the deposit

                    if (withdrawTransaction.Success)

                    {

                        DepositTransaction depositTransactionTest = new DepositTransaction(_toaccount, _amount);

                        depositTransactionTest.Execute();

                        // If deposit also successful

                        if (depositTransactionTest.Success)

                        {

                            _success = true;

                            _executed = true;

                            Print();

                        }

                        else // Deposit falied, rollback the withdrawTransaction

                        {

                            withdrawTransaction.Rollback();

                        }

                    }

                }

            }

            catch (InvalidOperationException e)

            {

                Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");

            }

        }

    }

}
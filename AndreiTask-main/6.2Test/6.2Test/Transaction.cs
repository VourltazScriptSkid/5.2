using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace _6._2Real
{

    public abstract class Transaction
    {
        public decimal _amount;
        public bool _success;
        public bool _executed;
        public bool _reversed;
        public DateTime _dateStamp;

        public abstract bool Success { get; }
        public bool Executed { get { return _executed; } }
        public bool Reversed { get { return _reversed; } }
        public DateTime DateStamp { get { return _dateStamp; } }



        public virtual string Type { get; }


        protected Transaction(decimal amount)
        {
            this._amount = amount;

        }

        public abstract void Print();


        public virtual void Execute()
        {
            _dateStamp = DateTime.Now;

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
            }

            catch (InvalidOperationException e)

            {
                PrintExeception(e);
            }

        }

        public virtual void Rollback()
        {

            _dateStamp = DateTime.Now;
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

            }

            catch (InvalidOperationException ex)

            {
                PrintExeception(ex);
            }
        }

        protected void PrintExeception(InvalidOperationException e)
        {

            Console.WriteLine("The following error detected: " + e.GetType().ToString() + " with message \"" + e.Message + "\"");
        }
    }
}

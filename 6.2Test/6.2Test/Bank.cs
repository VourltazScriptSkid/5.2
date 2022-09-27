using System;

using System.Collections.Generic;

using System.Linq;

namespace _6._2Real

{

    class Bank

    {
        // Provides a list of Created Accounts 
        private List<Account> accountList;

        public Bank()

        {

            accountList = new List<Account>();

        }

        public void AddAccount(Account account)

        {

            accountList.Add(account);

        }

        public Account GetAccount(String name)

        {

            return accountList.FirstOrDefault(a => a.Name == name);

        }

        public void ExecuteTransaction(DepositTransaction transaction)

        {

            transaction.Execute();

        }

        public void ExecuteTransaction(WithdrawTransaction transaction)

        {

            transaction.Execute();

        }

        public void ExecuteTransaction(TransferTransaction transaction)

        {

            transaction.Execute();

        }

    }

}
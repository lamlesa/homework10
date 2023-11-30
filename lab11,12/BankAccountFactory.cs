using System;
using System.Collections.Generic;

namespace lab11_12
{
    internal abstract class BankAccountFactory
    {
        HashSet<BankAccount> accounts = new HashSet<BankAccount> { };
        public ulong CreateAccount()
        {
            BankAccount account = new BankAccount();
            accounts.Add(account);
            return account.Number;
        }
        public ulong CreateAccount(AccountTypes type)
        {
            BankAccount account = new BankAccount(type);
            accounts.Add(account);
            return account.Number;
        }
        public void RemoveAccount(ulong number)
        {
            accounts.RemoveWhere(account => account.Number == number);
        }
    }
}
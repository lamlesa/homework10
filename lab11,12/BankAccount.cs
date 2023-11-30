using System;

namespace lab11_12
{
    internal partial class BankAccount : BankAccountFactory
    {
        static private ulong number = CreateAccountNumber();
        private double balance = 0;
        private AccountTypes type = AccountTypes.Current;
        public ulong Number { get { return number; } }
        public double Balance { get { return balance; } }
        public AccountTypes Type { get { return type; } }
        internal BankAccount()
        {
            number = CreateNewAccountNumber();
        }
        internal BankAccount(AccountTypes type)
        {
            this.type = type;
            number = CreateNewAccountNumber();
        }
        static private ulong CreateAccountNumber()
        {
            Random n = new Random();
            bool flag = false;
            do
            {
                flag = ulong.TryParse(Convert.ToString(n.Next(0)), out number);
            } while (!flag);
            return (number);
        }
        private ulong CreateNewAccountNumber()
        {
            number += 1;
            return (number);
        }
        public void WithdrawMoney(double sum)
        {
            if (sum < 0)
            {
                throw new ArgumentOutOfRangeException("Нельзя снять отрицательную сумму .");
            }
            else if (sum > balance)
            {
                throw new ArgumentOutOfRangeException("У вас нет таких денег.");
            }
            else
            {
                balance -= sum;
            }
        }
        public void PutMoney(double sum)
        {
            if (sum < 0)
            {
                throw new ArgumentOutOfRangeException("Нельзя положить отрицательную сумму .");
            }
            else
            {
                balance += sum;
            }
        }
        public void TransferMoney(ref BankAccount account_taker, double sum)
        {
            if (sum < 0)
            {
                throw new ArgumentOutOfRangeException("Нельзя перевести отрицательную сумму .");
            }
            else if (sum > balance)
            {
                throw new ArgumentOutOfRangeException("На счету недостаточно средств, чтобы перевести данную сумму .");
            }
            else
            {
                balance -= sum;
                account_taker.balance += sum;
            }
        }
        public void Print()
        {
            Console.WriteLine($"Номер счёта: {number}\nБаланс: {balance}\nТип счёта: {type}");
        }
    }
}
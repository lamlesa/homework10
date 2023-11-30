using System;

namespace lab11_12
{
    enum AccountTypes
    {
        Current,
        Savings
    }
    internal partial class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("( после каждого ввода стоит нажимать Enter )");
                double sum = 0;
                bool flag = false;
                byte type = 0;
                BankAccount primal_account = new BankAccount();
                Console.WriteLine("( 1 - текущий, 2 - сберегательный )");
                do
                {
                    Console.Write("Какой тип счёта? ");
                    flag = byte.TryParse(Console.ReadLine(), out type);
                    if ((type != 1) && (type != 2))
                    {
                        flag = false;
                    }
                } while (!flag);
                if (type == 1)
                {
                    primal_account.CreateAccount(AccountTypes.Current);
                }
                else
                {
                    primal_account.CreateAccount(AccountTypes.Savings);
                }
                do
                {
                    Console.Write("Сколько денег вы бы хотели снять со счёта? ");
                    flag = double.TryParse(Console.ReadLine(), out sum);
                } while (!flag);
                try
                {
                    primal_account.WithdrawMoney(sum);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                do
                {
                    Console.Write("Сколько денег вы бы хотели положить на счёт? ");
                    flag = double.TryParse(Console.ReadLine(), out sum);
                } while (!flag);
                try
                {
                    primal_account.PutMoney(sum);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                primal_account.CreateAccount();
                primal_account.Print();
            }
        }
    }
}
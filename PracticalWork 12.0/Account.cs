using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracrticalWork_12._0
{
    public interface IDepositable<out T>
    {
        T Deposit(decimal amount);
    }

    // Базовый класс для банковского счета
    public abstract class Account : IDepositable<Account>
    {
        public decimal Balance { get; protected set; }
        public Guid AccountId { get; private set; }

        public Account()
        {
            AccountId = Guid.NewGuid(); // Уникальный идентификатор счета
            Balance = 0; // Начальный баланс
        }

        public abstract Account Deposit(decimal amount); // Метод пополнения

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Недостаточно средств для снятия."); // Исключение при недостатке средств
            Balance -= amount; // Уменьшаем баланс
        }
        public void TransferTo<T>(T targetAccount, decimal amount) where T : Account
        {
            this.Withdraw(amount); // Снимаем средства с текущего счета
            targetAccount.Deposit(amount); // Переводим деньги на целевой счет
        }
    }

    // Класс, представляющий недепозитный счет
    public class NonDepositAccount : Account
    {
        public override Account Deposit(decimal amount)
        {
            throw new InvalidOperationException("Недепозитный счет не может быть пополнен."); // Исключение для недепозитного счета
        }
    }

    // Класс, представляющий депозитный счет
    public class DepositAccount : Account
    {
        public override Account Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Сумма должна быть положительной."); // Исключение для отрицательных сумм
            Balance += amount; // Пополняем депозитный счет
            return this; // Возвращаем текущий объект
        }
    }

}

namespace PracrticalWork_12._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bank = new Bank();
            var client = new Client("Иван Иванов");

            bank.AddClient(client);

            DepositAccount depositAccount = new DepositAccount();
            depositAccount.Deposit(1000); // Пополняем депозитный счет

            NonDepositAccount nonDepositAccount = new NonDepositAccount();

            try
            {
                depositAccount.TransferTo(nonDepositAccount, 200); // Переводим деньги на недепозитный счет
                Console.WriteLine("Перевод выполнен успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine($"Баланс депозитного счета: {depositAccount.Balance}");
            Console.WriteLine($"Баланс недепозитного счета: {nonDepositAccount.Balance}");
        }
    }
}

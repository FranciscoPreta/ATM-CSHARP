public class ATMOperations
{
    private CardHolder currentUser;

    public ATMOperations(CardHolder currentUser)
    {
        this.currentUser = currentUser;
    }

    public void Start()
    {
        int option = 0;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            switch (option)
            {
                case 1:
                    Deposit();
                    break;
                case 2:
                    Withdraw();
                    break;
                case 3:
                    CheckBalance();
                    break;
                case 4:
                    Console.WriteLine("Thank you!");
                    break;
                default:
                    option = 0;
                    break;
            }
        } while (option != 4);
    }

    private void PrintOptions()
    {
        Console.WriteLine("\n Choose one of the following options:");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. Exit\n");
    }

    private void Deposit()
    {
        Console.WriteLine("How much money would you like to deposit?\n");
        double deposit = double.Parse(Console.ReadLine());
        currentUser.setBalance(deposit);
        PrintTransactionMessage($"Thank you for your deposit. Your current balance is: {currentUser.getBalance()}€");
    }

    private void Withdraw()
    {
        Console.WriteLine("How much money would you like to withdraw?\n");
        double withdraw = double.Parse(Console.ReadLine());
        if (currentUser.getBalance() >= withdraw)
        {
            currentUser.setBalance(-withdraw);
            PrintTransactionMessage($"Thank you for your withdrawal. Your current balance is: {currentUser.getBalance()}€");
        }
        else
        {
            Console.WriteLine("Not enough funds or invalid prompt.\n");
        }
    }

    private void CheckBalance()
    {
        PrintTransactionMessage($"Your current balance is: {currentUser.getBalance()}€");
    }

    private void PrintTransactionMessage(string message)
    {
        Console.BackgroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
class ATMProgram
{
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("\n Choose one of the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit\n");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?\n");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thank you for your deposit. Your current balance is: {currentUser.getBalance()}€");
            Console.ResetColor();
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw?\n");
            double withdraw = double.Parse(Console.ReadLine());
            if (currentUser.getBalance() >= withdraw)
            {
                currentUser.setBalance(-withdraw);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Thank you for your withdraw. Your current balance is: {currentUser.getBalance()}€");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Not enough funds or invalid prompt.\n");
            }
        }

        void checkBalance(cardHolder currentUser)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your current balance is: {currentUser.getBalance()}€");
            Console.ResetColor();
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder(1, 1234, "Francisco", "Preta", 15000));
        cardHolders.Add(new cardHolder(2, 1221, "José", "Santos", 150));
        cardHolders.Add(new cardHolder(3, 1111, "Álvaro", "Hilário", 15));

        Console.WriteLine("Welcome to PretaATM");
        Console.WriteLine("Plese insert your debit card: \n");
        int debitCardNum = 0;
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.getNum() == debitCardNum);
                if (currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.\n");
                }
            }
            catch { Console.WriteLine("Card not recognized. Please try again.\n"); }
        }

        Console.WriteLine("Please enter yout pin!");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else
                {
                    Console.WriteLine("Incorrect Pin. Try Again.\n");
                }
            }
            catch { Console.WriteLine("Incorrect Pin. Try Again.\n"); }
        }

        Console.WriteLine($"Welcome, {currentUser.getFirstName()}\n");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { checkBalance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        } while (option != 4);
        Console.WriteLine("Thank you!");
    }
}
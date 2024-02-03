public class ATMSystem
{
    private List<CardHolder> cardHolders;

    public ATMSystem()
    {
        cardHolders = new List<CardHolder>
        {
            new CardHolder(1, 1234, "Francisco", "Preta", 15000),
            new CardHolder(2, 1221, "José", "Santos", 150),
            new CardHolder(3, 1111, "Álvaro", "Hilário", 15)
        };
    }

    public void run()
    {
        Console.WriteLine("Welcome to PretaATM");
        Console.WriteLine("Please insert your debit card: \n");
        int debitCardNum = 0;
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.getCardNum() == debitCardNum);
                if (currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again.\n");
                }
            }
            catch { Console.WriteLine("Card not recognized. Please try again.\n"); }
        }

        Console.WriteLine("Please enter your pin!");
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
        ATMOperations atmOperations = new ATMOperations(currentUser);
        atmOperations.Start();
    }
}
using System;

public class TravelCard
{
    //fields
    private string _cardNumber;
    private decimal _balance;

    public TravelCard(string cardNumber, decimal initialBalance)
    {
        if (initialBalance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(initialBalance));
        }
        _cardNumber = cardNumber;
        _balance = initialBalance;
    }

    //properties
    public string CardNumber => _cardNumber;
    public decimal Balance => _balance;

    //methods
    public bool TopUp(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        else
        {
            _balance += amount;
            return true;
        }
    }

    private bool HasEnoughBalance(decimal amount)
    {
        if (_balance >= amount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Pay(decimal amount)
    {
        if (amount <= 0)
        {
            return false;
        }
        else if (HasEnoughBalance(amount))
        {
            _balance -= amount;
            return true;
        }
        else 
        {
            return false;
        }
    }
}
class Program
{
    static void Main()
    {
        TravelCard card1 = new("TC01", 100);
        TravelCard card2 = new("TC02", 0);
        TravelCard card3 = new("TC03", -1);

        Console.WriteLine(card1.Pay(30));
        Console.WriteLine(card1.Balance);

        Console.WriteLine(card1.Pay(80));
        Console.WriteLine(card1.Balance);

        Console.WriteLine(card1.TopUp(50));
        Console.WriteLine(card1.Balance);

        Console.WriteLine(card1.Pay(80));
        Console.WriteLine(card1.Balance);

        Console.WriteLine(card2.TopUp(-10));
        Console.WriteLine(card2.Balance);

        Console.WriteLine(card2.Pay(1));
        Console.WriteLine(card2.Balance);
    }
}
// See https://aka.ms/new-console-template for more information

public class Card
{
    public Color Color { get; }
    public Value Value { get; }

    public Card(Value value, Color color)
    {
        Value = value;
        Color = color;
    }
}
/// <summary>
///  Kolory
/// </summary>
public enum Color
{
    Spades,
    Hearts,
    Diamonds,
    Clubs
}

/// <summary>
/// Wartośći
/// </summary>
public enum Value
{
    Ace = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public class CardDeck
{
    private List<Card> cards;

    public CardDeck()
    {
        cards = GenerateDeck();
    }

    /// <summary>
    /// Tworzenie Decku
    /// </summary>
    private List<Card> GenerateDeck()
    {
        List<Card> deck = new List<Card>();
        foreach (Color color in Enum.GetValues(typeof(Color)))
        {
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                Card card = new Card(value, color);
                deck.Add(card);
            }
        }

        return deck;
    }
    /// <summary>
    /// Tasowanie 
    /// </summary>
    public void Shuffle()
    {
        Random random = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
    /// <summary>
    /// Pobieranie karty z góry decku
    /// </summary>
    /// <exception cref="InvalidOperationException"> Deck jest pusty</exception>
    /// <returns>Błąd Pusty Deck</returns>
    public Card DealCard()
    {
        if (cards.Count == 0)
        {
            throw new InvalidOperationException("The deck is empty. No more cards to deal.");
        }

        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
public class PlayerHand
{
    public List<Card> PlayerCards { get; }
    public List<Card> TableCards { get; }


    public PlayerHand()
    {
        PlayerCards = new List<Card>();
        TableCards = new List<Card>();
    }
    /// <summary>
    /// Dodawanie karty do ręki gracza
    /// </summary>
    /// <param name="card"> Karta </param>
    public void AddPlayerCard(Card card)
    {
        PlayerCards.Add(card);
    }



    /// <summary>
    /// Dodawanie karty do kart na stole (wspolnych)
    /// </summary>
    /// <param name="card"> Karta </param>
    public void AddTableCard(Card card)
    {
        TableCards.Add(card);
    }


}
public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }
    public int Chips { get; private set; }
    public int CurrentBet { get; private set; }

    public Player(string name, int startingChips)
    {
        Name = name;
        Hand = new List<Card>();
        Chips = startingChips;
        CurrentBet = 0;
    }

    public void DealCards(Card card)
    {
        Hand.Add(card);
    }
    public void PlaceBet(int amount)
    {
        if (amount > Chips)
        {
            amount = Chips;
        }
        Chips -= amount;
        CurrentBet += amount;
    }

    public void Fold()
    {
        Hand.Clear();
        CurrentBet = 0;
    }
    public void ClearHand()
    {
        Hand.Clear();
    }

}
public class Round
{
    private CardDeck deck;
    private List<Player> players;
    private List<Card> TableCards;
    public Round(List<Player> players)
    {
        this.players = players;
        deck = new CardDeck();
        TableCards = new List<Card>();
    }

    public void Start()
    {
        foreach (Player player in players)
        {
            player.ClearHand();
            player.DealCards(deck.DealCard());
            player.DealCards(deck.DealCard());
        }
        DealTableCard(3);
        DealTableCard(1);
        DealTableCard(1);
    }
    private void DealTableCard(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Card card = deck.DealCard();
            TableCards.Add(card);
        }
    }

    public class PokerGame
    {
        private List<Player> players;
        private int currentPlayerIndex;
        private int roundNumber;
        private Round currentRound;

    public PokerGame(List<Player> players)
        {
            this.players =players;
            currentPlayerIndex = 0;
            roundNumber = 1;
            currentRound = null;
        }

    public void Start()
        {
            Console.WriteLine("Rozpoczyna się gra w pokera!");
            Console.WriteLine("=================================");
            Console.WriteLine();
            while (!IsGameOver())
            {
                Console.WriteLine("Runda numer: " + roundNumber);
                Console.WriteLine("--------------------------");
                Console.WriteLine();

                StartNewRound();

                // Sprawdzenie warunków końca gry
                if (IsGameOver())
                {
                    break;
                }

                // Przejście do następnego gracza
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
                roundNumber++;

                // dodac ruchy itd
            }

            // Wyświetlenie zwycięzcy
            Player winner = DetermineWinner();
            Console.WriteLine("=================================");
            Console.WriteLine("Gra zakończona! Zwycięzca: " + winner.Name);



        }
        private void StartNewRound()
        {
            Console.WriteLine("Nowa runda:");
            Console.WriteLine();

            currentRound = new Round(players);
            currentRound.Start();

           // dodanie obslugi zakladow podejmowanie decyzji itd
        }

        private bool IsGameOver()
        {

            return false;
        }

        private Player DetermineWinner()
        {
            
           
            // stworzyc how to win

            return players[0]; 
        }

    }

}





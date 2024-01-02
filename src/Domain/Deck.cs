namespace Domain;



public class Deck
    {
    private Random random;
    protected IList<BlackJackCard> cards;

    public Deck()
        {
        random = new Random();
        cards = new List<BlackJackCard>(52);

        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
            foreach (FaceValue faceValue in Enum.GetValues(typeof(FaceValue)))
                {
                cards.Add(new BlackJackCard(suit, faceValue));
                }
            }
        }

    public BlackJackCard Draw()
        {
        if (cards.Count == 0)
            {
            throw new InvalidOperationException("No more cards are left in the deck");
            }

        BlackJackCard card = cards[0];
        cards.RemoveAt(0);
        return card;
        }

    private void Shuffle()
        {
        for (int i = 0; i < cards.Count * 3; i++)
            {
            int randomPosition = random.Next(0, cards.Count);
            var card = cards[randomPosition];
            cards.RemoveAt(randomPosition);
            cards.Add(card);
            }
        }

    }


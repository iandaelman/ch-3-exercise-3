namespace Domain;

public class Hand
    {


    private IList<BlackJackCard> cards;

    public IEnumerable<BlackJackCard> Cards => cards;
    public int NrOfCards => cards.Count;
    public int Value => CalcualteValue();

    public Hand()
        {
        cards = new List<BlackJackCard>();
        }

    public void AddCard(BlackJackCard card)
        {
        cards.Add(card);

        }
    public void TurnAllCardsFaceUp()
        {
        foreach (BlackJackCard card in cards)
            {
            if (!card.FaceUp)
                {
                card.TurnCard();
                }
            }
        }

    private int CalcualteValue()
        {
        int value = 0;
        bool hasAce = false;
        foreach (BlackJackCard card in Cards)
            {
            value += card.Value;

            if (card.FaceUp && card.FaceValue == FaceValue.Ace)
                {
                hasAce = true;
                }


            }

        if (hasAce && (value + 10) <= 21)
            {
            value += 10;
            }

        return value;
        }
    }


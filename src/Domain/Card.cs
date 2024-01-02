namespace Domain;

public class Card
    {
    public FaceValue FaceValue { get; }
    public Suit Suit { get; }

    public Card(Suit suit, FaceValue faceValue)
        {
        Suit = suit;
        FaceValue = faceValue;
        }
    }

